using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Freight.Services;

namespace Freight
{
    public partial class ProgramForm1 : ModernForm
    {
        private LowLevelKeyboardHook keyboardHook;
        private LowLevelMouseHook mouseHook;
        private bool isSettingsFormOpen = false;

        // 시스템 볼륨 조절 컨트롤 변수
        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int APPCOMMAND_VOLUME_UP = 0xA0000;
        private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
        private const int WM_APPCOMMAND = 0x319;

        // ====== Win32 API 선언 ======
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

        [DllImport("user32.dll")]
        private static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);

        [DllImport("kernel32.dll")]
        private static extern uint GetCurrentThreadId();

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_RESTORE = 9;
        private const int SW_MAXIMIZE = 3;
        private const int SW_SHOWNORMAL = 1;

        // 창 최대화 상태 확인용
        [DllImport("user32.dll")]
        private static extern bool IsZoomed(IntPtr hWnd);

        // 모니터 관련 API
        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr MonitorFromWindow(IntPtr hwnd, uint dwFlags);

        [DllImport("user32.dll")]
        private static extern bool GetMonitorInfo(IntPtr hMonitor, ref MONITORINFO lpmi);

        private const uint MONITOR_DEFAULTTONEAREST = 2;
        private const uint SWP_NOZORDER = 0x0004;
        private const uint SWP_NOSIZE = 0x0001;

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MONITORINFO
        {
            public int cbSize;
            public RECT rcMonitor;
            public RECT rcWork;
            public uint dwFlags;
        }
        // ===========================

        // 모니터 복제, 확장 모드
        enum DisplayMode
        {
            Internal,
            External,
            Extend,
            Duplicate
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg,
            IntPtr wParam, IntPtr lParam);

        public ProgramForm1()
        {
            try
            {
                InitializeComponent();
                Shown += new EventHandler(ProgramForm1_Load);
                FormClosing += new FormClosingEventHandler(ProgramForm1_FormClosing);

                // 검색 아이콘 그리기
                DrawSearchIcon();

                // Placeholder 텍스트 설정
                SetPlaceholder();

                // 전역 키보드 후킹 설정
                keyboardHook = new LowLevelKeyboardHook();
                keyboardHook.KeyDown += KeyboardHook_KeyDown;
                keyboardHook.Hook();

                // 전역 마우스 후킹 설정 (작업표시줄 볼륨 조절용)
                mouseHook = new LowLevelMouseHook();
                bool hookResult = mouseHook.Hook();
                if (!hookResult)
                {
                    MessageBox.Show("마우스 후킹 실패!", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"폼 초기화 중 오류:\n{ex.Message}\n\nStackTrace:\n{ex.StackTrace}",
                    "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void KeyboardHook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                e.Handled = true;  // 다른 앱에 전달하지 않음
                // UI 스레드에서 실행
                this.BeginInvoke((MethodInvoker)delegate
                {
                    if (this.Visible)
                    {
                        this.Hide();
                    }
                    else
                    {
                        this.Show();
                        ForceActivate();
                        RemovePlaceholder();
                        InputCommandBox.ForeColor = Color.FromArgb(220, 220, 220);
                    }
                });
            }
            // Ctrl+Shift+S: copy.txt 경로를 클립보드에 복사
            else if (keyboardHook.IsCtrlPressed && keyboardHook.IsShiftPressed && e.KeyCode == Keys.S)
            {
                e.Handled = true;  // 다른 앱에 전달하지 않음
                this.BeginInvoke((MethodInvoker)delegate
                {
                    CopyPathFromFile();
                });
            }
            // Ctrl+Shift+Z: 다음 모니터로 창 이동
            else if (keyboardHook.IsCtrlPressed && keyboardHook.IsShiftPressed && e.KeyCode == Keys.Z)
            {
                e.Handled = true;  // 다른 앱에 전달하지 않음
                this.BeginInvoke((MethodInvoker)delegate
                {
                    MoveWindowToNextMonitor();
                });
            }
            // Ctrl+Shift+A: 창 최대화/복원 토글
            else if (keyboardHook.IsCtrlPressed && keyboardHook.IsShiftPressed && e.KeyCode == Keys.A)
            {
                e.Handled = true;  // 다른 앱에 전달하지 않음
                this.BeginInvoke((MethodInvoker)delegate
                {
                    ToggleMaximizeWindow();
                });
            }
        }

        private void DrawSearchIcon()
        {
            Bitmap bmp = new Bitmap(32, 32);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.Clear(Color.FromArgb(30, 30, 30));

                using (Pen pen = new Pen(Color.FromArgb(150, 150, 150), 3))
                {
                    // 돋보기 원
                    g.DrawEllipse(pen, 4, 4, 18, 18);
                    // 돋보기 손잡이
                    pen.Width = 3.5f;
                    g.DrawLine(pen, 18, 18, 28, 28);
                }
            }
            pictureBoxSearch.Image = bmp;
        }

        private void SetPlaceholder()
        {
            if (string.IsNullOrEmpty(InputCommandBox.Text))
            {
                InputCommandBox.Text = "명령어를 입력하세요...";
                InputCommandBox.ForeColor = Color.LightGray;
            }
        }

        private void RemovePlaceholder()
        {
            if (InputCommandBox.Text == "명령어를 입력하세요...")
            {
                InputCommandBox.Text = "";
                InputCommandBox.ForeColor = Color.Black;
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            isSettingsFormOpen = true;
            using (SettingsForm settingsForm = new SettingsForm())
            {
                settingsForm.SettingsApplied += (s, args) => ApplyAppearanceSettings();
                settingsForm.ShowDialog(this);
            }
            isSettingsFormOpen = false;
        }

        private void ApplyAppearanceSettings()
        {
            var settings = ConfigManager.Instance.Settings;

            try
            {
                // 폰트 적용
                Font newFont = new Font(settings.FontName, settings.FontSize);
                InputCommandBox.Font = newFont;

                // 배경색 적용
                Color bgColor = Color.FromArgb(settings.BackgroundColor);
                this.BackColor = bgColor;
                InputCommandBox.BackColor = bgColor;

                // 텍스트 색상 적용
                Color textColor = Color.FromArgb(settings.TextColor);
                InputCommandBox.ForeColor = textColor;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"설정 적용 중 오류: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Complete termination
            keyboardHook?.Unhook();
            mouseHook?.Unhook();
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ProgramForm1_Load(object sender, EventArgs e)
        {
            // 저장된 설정 적용
            ApplyAppearanceSettings();

            // 프로그램 시작 시 자동으로 숨김
            Hide();
        }

        public void ProgramForm1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 프로그램 종료 시 후킹 해제
            if (e.CloseReason == CloseReason.WindowsShutDown ||
                e.CloseReason == CloseReason.ApplicationExitCall)
            {
                keyboardHook?.Unhook();
                mouseHook?.Unhook();
            }
            else
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        // Public method to terminate the application completely
        public static void TerminateApplication()
        {
            Application.Exit();
        }

        // ====== 강제 활성화 메서드 ======
        private void ForceActivate()
        {
            // 약간의 지연을 두고 여러 번 시도
            for (int i = 0; i < 3; i++)
            {
                IntPtr foregroundWindow = GetForegroundWindow();
                uint foregroundThreadId = 0;
                GetWindowThreadProcessId(foregroundWindow, out foregroundThreadId);
                uint currentThreadId = GetCurrentThreadId();

                if (foregroundThreadId != currentThreadId)
                {
                    AttachThreadInput(currentThreadId, foregroundThreadId, true);
                }

                this.TopMost = true;
                this.TopMost = false;
                
                ShowWindow(this.Handle, SW_RESTORE);
                SetForegroundWindow(this.Handle);
                this.BringToFront();
                this.Activate();
                this.Focus();

                if (foregroundThreadId != currentThreadId)
                {
                    AttachThreadInput(currentThreadId, foregroundThreadId, false);
                }

                Application.DoEvents();
                System.Threading.Thread.Sleep(10); // 10ms 대기
            }

            InputCommandBox.Focus();
        }

        // ====== 비활성화 방지 ======
        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);

            // 설정창이 열려있을 때는 오토포커스 비활성화
            if (isSettingsFormOpen)
                return;

            if (this.Visible)
            {
                Timer timer = new Timer();
                timer.Interval = 120;
                timer.Tick += (s, args) =>
                {
                    timer.Stop();
                    timer.Dispose();

                    if (this.Visible && !isSettingsFormOpen)
                    {
                        ForceActivate();
                    }
                };
                timer.Start();
            }
        }


        // 엔터를 치면 검색이되는 코드
        private void InputCommandBox_KeyDown(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;

                string command = InputCommandBox.Text.Trim();

                // 빈 입력이거나 플레이스홀더인 경우 Google로 이동
                if (string.IsNullOrEmpty(command) || command == "명령어를 입력하세요...")
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = "https://www.google.com",
                            UseShellExecute = true
                        });
                    }
                    catch { }
                }
                // URL 직접 입력 (http:// 또는 https://로 시작)
                else if (command.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                         command.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = command,
                            UseShellExecute = true
                        });
                    }
                    catch { }
                }
                // 종료 명령어 체크
                else if (command.StartsWith("꺼져") || command.StartsWith("종료") ||
                         command.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    keyboardHook?.Unhook();
                    mouseHook?.Unhook();
                    Application.Exit();
                    return;
                }
                // 일반 명령어 처리
                else
                {
                    Analyze az = new Analyze(command);
                    Run r = new Run(az);
                }

                this.InputCommandBox.Clear();
                SetPlaceholder();

                Hide();
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                e.Handled = true;
                this.InputCommandBox.Clear();
                SetPlaceholder();
                Hide();
            }
        }

        // GlobalEventProvider 제거됨 - F8 키 기능은 수동으로 실행해야 함
        // TODO: 나중에 다른 전역 후킹 라이브러리로 교체 필요

        /// <summary>
        /// Ctrl+Shift+S: copy.txt 파일에서 경로를 읽어 클립보드에 복사
        /// </summary>
        private void CopyPathFromFile()
        {
            try
            {
                // 프로그램 설치 폴더에서 copy.txt 읽기
                string copyFilePath = Path.Combine(Application.StartupPath, "copy.txt");
                if (File.Exists(copyFilePath))
                {
                    string path = File.ReadAllText(copyFilePath).Trim();
                    if (!string.IsNullOrEmpty(path))
                    {
                        Clipboard.SetText(path);
                    }
                }
            }
            catch (Exception ex)
            {
                // 오류 무시 (백그라운드 작업)
                Debug.WriteLine($"CopyPathFromFile 오류: {ex.Message}");
            }
        }

        /// <summary>
        /// Ctrl+Shift+Z: 현재 활성화된 창을 다음 모니터로 이동
        /// </summary>
        private void MoveWindowToNextMonitor()
        {
            try
            {
                IntPtr hWnd = GetForegroundWindow();
                if (hWnd == IntPtr.Zero) return;

                // 모니터가 2개 이상인지 확인
                Screen[] screens = Screen.AllScreens;
                if (screens.Length < 2) return;

                // 전체화면 상태 확인
                bool wasMaximized = IsZoomed(hWnd);

                // 전체화면이면 먼저 복원 (이동을 위해)
                if (wasMaximized)
                {
                    ShowWindow(hWnd, SW_RESTORE);
                    // 복원 후 창 상태가 반영될 때까지 잠시 대기
                    System.Threading.Thread.Sleep(50);
                }

                // 현재 창의 위치 가져오기 (복원 후)
                GetWindowRect(hWnd, out RECT windowRect);
                int windowCenterX = (windowRect.Left + windowRect.Right) / 2;
                int windowCenterY = (windowRect.Top + windowRect.Bottom) / 2;

                // 현재 창이 있는 모니터 찾기
                int currentMonitorIndex = -1;
                for (int i = 0; i < screens.Length; i++)
                {
                    if (screens[i].Bounds.Contains(windowCenterX, windowCenterY))
                    {
                        currentMonitorIndex = i;
                        break;
                    }
                }

                if (currentMonitorIndex == -1) currentMonitorIndex = 0;

                // 다음 모니터 인덱스 계산
                int nextMonitorIndex = (currentMonitorIndex + 1) % screens.Length;
                Screen nextScreen = screens[nextMonitorIndex];

                // 창 크기 계산
                int windowWidth = windowRect.Right - windowRect.Left;
                int windowHeight = windowRect.Bottom - windowRect.Top;

                // 다음 모니터의 중앙에 창 배치 (전체화면이었던 경우)
                int newX, newY;
                if (wasMaximized)
                {
                    // 전체화면이었으면 다음 모니터 중앙에 배치
                    newX = nextScreen.WorkingArea.Left + (nextScreen.WorkingArea.Width - windowWidth) / 2;
                    newY = nextScreen.WorkingArea.Top + (nextScreen.WorkingArea.Height - windowHeight) / 2;
                }
                else
                {
                    // 일반 창이면 상대 위치 유지
                    Screen currentScreen = screens[currentMonitorIndex];
                    int relativeX = windowRect.Left - currentScreen.Bounds.Left;
                    int relativeY = windowRect.Top - currentScreen.Bounds.Top;
                    newX = nextScreen.Bounds.Left + relativeX;
                    newY = nextScreen.Bounds.Top + relativeY;
                }

                // 창이 화면 밖으로 나가지 않도록 조정
                if (newX + windowWidth > nextScreen.WorkingArea.Right)
                    newX = nextScreen.WorkingArea.Right - windowWidth;
                if (newY + windowHeight > nextScreen.WorkingArea.Bottom)
                    newY = nextScreen.WorkingArea.Bottom - windowHeight;
                if (newX < nextScreen.WorkingArea.Left)
                    newX = nextScreen.WorkingArea.Left;
                if (newY < nextScreen.WorkingArea.Top)
                    newY = nextScreen.WorkingArea.Top;

                // 창 이동
                SetWindowPos(hWnd, IntPtr.Zero, newX, newY, 0, 0, SWP_NOZORDER | SWP_NOSIZE);

                // 전체화면이었으면 다시 전체화면으로
                if (wasMaximized)
                {
                    // 창이 새 모니터에 정착될 때까지 잠시 대기
                    System.Threading.Thread.Sleep(50);
                    ShowWindow(hWnd, SW_MAXIMIZE);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"MoveWindowToNextMonitor 오류: {ex.Message}");
            }
        }

        /// <summary>
        /// Ctrl+Shift+A: 현재 활성화된 창 최대화/복원 토글
        /// </summary>
        private void ToggleMaximizeWindow()
        {
            try
            {
                IntPtr hWnd = GetForegroundWindow();
                if (hWnd == IntPtr.Zero) return;

                if (IsZoomed(hWnd))
                {
                    // 최대화된 상태면 복원
                    ShowWindow(hWnd, SW_RESTORE);
                }
                else
                {
                    // 최대화되지 않은 상태면 최대화
                    ShowWindow(hWnd, SW_MAXIMIZE);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ToggleMaximizeWindow 오류: {ex.Message}");
            }
        }

        private void ProgramForm1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void SetDisplayMode(DisplayMode mode)
        {
            var proc = new Process();
            string str = @"C:\WINDOWS\system32\displayswitch.exe";
            proc.StartInfo.FileName = str;

            if (System.IO.File.Exists(str))
            {
                switch (mode)
                {
                    case DisplayMode.External:
                        proc.StartInfo.Arguments = "/external";
                        break;
                    case DisplayMode.Internal:
                        proc.StartInfo.Arguments = "/internal";
                        break;
                    case DisplayMode.Extend:
                        proc.StartInfo.Arguments = "/extend";
                        break;
                    case DisplayMode.Duplicate:
                        proc.StartInfo.Arguments = "/clone";
                        break;
                }
                proc.Start();
            }
            else
            {
                MessageBox.Show("파일이 엄서요~~~");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("gg");
        }

        private void InputCommandBox_TextChanged(object sender, EventArgs e)
        {
            RemovePlaceholder();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            InputCommandBox.Focus();
            RemovePlaceholder();
        }

        private void ProgramForm1_Load_1(object sender, EventArgs e)
        {
            this.BorderRadius = 0;
        }
    }
}
