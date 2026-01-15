using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Freight
{
    /// <summary>
    /// 마우스 제스처를 화면에 그리는 투명 오버레이 폼
    /// UpdateLayeredWindow를 사용하여 per-pixel alpha 지원
    /// 최적화: DC와 비트맵을 재사용하여 성능 향상
    /// </summary>
    public class GestureOverlayForm : Form
    {
        private List<Point> points = new List<Point>();
        private float penWidth;
        private Bitmap bitmap;
        private Rectangle virtualScreen;

        // 재사용할 GDI 리소스
        private IntPtr screenDc = IntPtr.Zero;
        private IntPtr memDc = IntPtr.Zero;
        private Pen gesturePen;
        private SolidBrush startPointBrush;

        // 투명 윈도우를 위한 상수
        private const int WS_EX_LAYERED = 0x80000;
        private const int WS_EX_TOOLWINDOW = 0x80;
        private const int WS_EX_TOPMOST = 0x8;
        private const int WS_EX_NOACTIVATE = 0x8000000;

        private const int ULW_ALPHA = 0x02;
        private const byte AC_SRC_OVER = 0x00;
        private const byte AC_SRC_ALPHA = 0x01;

        #region Win32 API

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int x;
            public int y;

            public POINT(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct SIZE
        {
            public int cx;
            public int cy;

            public SIZE(int cx, int cy)
            {
                this.cx = cx;
                this.cy = cy;
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct BLENDFUNCTION
        {
            public byte BlendOp;
            public byte BlendFlags;
            public byte SourceConstantAlpha;
            public byte AlphaFormat;
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst,
            ref POINT pptDst, ref SIZE psize, IntPtr hdcSrc, ref POINT pptSrc,
            uint crKey, ref BLENDFUNCTION pblend, uint dwFlags);

        [DllImport("gdi32.dll", SetLastError = true)]
        private static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [DllImport("gdi32.dll", SetLastError = true)]
        private static extern bool DeleteDC(IntPtr hdc);

        [DllImport("gdi32.dll", SetLastError = true)]
        private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        [DllImport("gdi32.dll", SetLastError = true)]
        private static extern bool DeleteObject(IntPtr hObject);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        #endregion

        public GestureOverlayForm()
        {
            InitializeForm();
            CalculatePenWidth();
            CreateDrawingResources();
        }

        private void InitializeForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.StartPosition = FormStartPosition.Manual;

            virtualScreen = SystemInformation.VirtualScreen;
            this.Location = new Point(virtualScreen.Left, virtualScreen.Top);
            this.Size = new Size(virtualScreen.Width, virtualScreen.Height);

            bitmap = new Bitmap(virtualScreen.Width, virtualScreen.Height, PixelFormat.Format32bppPArgb);
        }

        private void CreateDrawingResources()
        {
            // 보라색 펜과 브러시 미리 생성
            Color purpleColor = Color.FromArgb(200, 155, 89, 182);
            gesturePen = new Pen(purpleColor, penWidth)
            {
                StartCap = LineCap.Round,
                EndCap = LineCap.Round,
                LineJoin = LineJoin.Round
            };
            startPointBrush = new SolidBrush(Color.FromArgb(220, 155, 89, 182));
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= WS_EX_LAYERED | WS_EX_TOOLWINDOW | WS_EX_TOPMOST | WS_EX_NOACTIVATE;
                return cp;
            }
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_NCHITTEST = 0x84;
            const int HTTRANSPARENT = -1;

            if (m.Msg == WM_NCHITTEST)
            {
                m.Result = (IntPtr)HTTRANSPARENT;
                return;
            }
            base.WndProc(ref m);
        }

        private void CalculatePenWidth()
        {
            using (Graphics g = CreateGraphics())
            {
                float dpiX = g.DpiX;
                penWidth = 0.59055f * dpiX;
                if (penWidth < 20) penWidth = 20;
                if (penWidth > 100) penWidth = 100;
            }
        }

        public void UpdatePoints(List<Point> gesturePoints)
        {
            points.Clear();
            foreach (Point p in gesturePoints)
            {
                // dpiAware=false이므로 좌표 변환 없이 직접 사용
                points.Add(new Point(p.X - virtualScreen.Left, p.Y - virtualScreen.Top));
            }

            DrawToBitmapFast();
            UpdateLayeredBitmapFast();
        }

        private void DrawToBitmapFast()
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.Transparent);

                if (points.Count < 2)
                    return;

                g.SmoothingMode = SmoothingMode.AntiAlias;

                Point[] pointArray = points.ToArray();
                g.DrawLines(gesturePen, pointArray);

                // 시작점 원
                float circleSize = penWidth * 1.2f;
                g.FillEllipse(startPointBrush,
                    pointArray[0].X - circleSize / 2,
                    pointArray[0].Y - circleSize / 2,
                    circleSize, circleSize);
            }
        }

        private void UpdateLayeredBitmapFast()
        {
            if (bitmap == null || !this.IsHandleCreated)
                return;

            IntPtr hBitmap = IntPtr.Zero;
            IntPtr oldBitmap = IntPtr.Zero;
            IntPtr localScreenDc = IntPtr.Zero;
            IntPtr localMemDc = IntPtr.Zero;

            try
            {
                localScreenDc = GetDC(IntPtr.Zero);
                localMemDc = CreateCompatibleDC(localScreenDc);

                hBitmap = bitmap.GetHbitmap(Color.FromArgb(0));
                oldBitmap = SelectObject(localMemDc, hBitmap);

                POINT pointSource = new POINT(0, 0);
                POINT topPos = new POINT(virtualScreen.Left, virtualScreen.Top);
                SIZE size = new SIZE(bitmap.Width, bitmap.Height);

                BLENDFUNCTION blend = new BLENDFUNCTION
                {
                    BlendOp = AC_SRC_OVER,
                    BlendFlags = 0,
                    SourceConstantAlpha = 255,
                    AlphaFormat = AC_SRC_ALPHA
                };

                UpdateLayeredWindow(this.Handle, localScreenDc, ref topPos, ref size,
                    localMemDc, ref pointSource, 0, ref blend, ULW_ALPHA);
            }
            finally
            {
                if (oldBitmap != IntPtr.Zero && localMemDc != IntPtr.Zero)
                    SelectObject(localMemDc, oldBitmap);
                if (hBitmap != IntPtr.Zero)
                    DeleteObject(hBitmap);
                if (localMemDc != IntPtr.Zero)
                    DeleteDC(localMemDc);
                if (localScreenDc != IntPtr.Zero)
                    ReleaseDC(IntPtr.Zero, localScreenDc);
            }
        }

        public void ShowOverlay()
        {
            points.Clear();

            virtualScreen = SystemInformation.VirtualScreen;
            this.Location = new Point(virtualScreen.Left, virtualScreen.Top);
            this.Size = new Size(virtualScreen.Width, virtualScreen.Height);

            if (bitmap == null || bitmap.Width != virtualScreen.Width || bitmap.Height != virtualScreen.Height)
            {
                bitmap?.Dispose();
                bitmap = new Bitmap(virtualScreen.Width, virtualScreen.Height, PixelFormat.Format32bppPArgb);
            }

            // 비트맵을 완전히 투명하게 클리어
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.Transparent);
            }

            // 먼저 투명한 상태로 레이어 업데이트 후 표시
            UpdateLayeredBitmapFast();
            this.Show();
        }

        public void HideOverlay()
        {
            points.Clear();
            this.Hide();

            // 다음 제스처를 위해 비트맵 클리어
            if (bitmap != null)
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.Clear(Color.Transparent);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // UpdateLayeredWindow handles painting
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                bitmap?.Dispose();
                gesturePen?.Dispose();
                startPointBrush?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
