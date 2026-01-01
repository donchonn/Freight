using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Freight
{
    /// <summary>
    /// 저수준 마우스 후킹 클래스 - 작업표시줄 위에서 스크롤로 볼륨 조절
    /// 2.3 버전 방식 적용: WindowFromPoint + GetAncestor 사용
    /// </summary>
    public class LowLevelMouseHook : IDisposable
    {
        private const int WH_MOUSE_LL = 14;
        private const int WM_MOUSEWHEEL = 0x020A;
        private const int WM_APPCOMMAND = 0x319;
        private const int APPCOMMAND_VOLUME_UP = 0xA0000;
        private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
        private const uint GA_ROOTOWNER = 3;

        private static LowLevelMouseProc _proc;
        private static IntPtr _hookID = IntPtr.Zero;
        private bool _disposed = false;

        public LowLevelMouseHook()
        {
            _proc = HookCallback;
        }

        public bool Hook()
        {
            if (_hookID == IntPtr.Zero)
            {
                // 2.3 버전 방식: GetModuleHandle("user32") 사용
                _hookID = SetWindowsHookEx(WH_MOUSE_LL, _proc, GetModuleHandle("user32"), 0);

                if (_hookID == IntPtr.Zero)
                {
                    int error = Marshal.GetLastWin32Error();
                    System.Diagnostics.Debug.WriteLine($"Mouse hook failed. Error: {error}");
                    return false;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Mouse hook installed successfully");
                    return true;
                }
            }
            return true;
        }

        public void Unhook()
        {
            if (_hookID != IntPtr.Zero)
            {
                UnhookWindowsHookEx(_hookID);
                _hookID = IntPtr.Zero;
                System.Diagnostics.Debug.WriteLine("Mouse hook removed");
            }
        }

        /// <summary>
        /// 2.3 버전 방식: WindowFromPoint + GetAncestor로 작업표시줄 확인
        /// </summary>
        private static bool IsMouseOverTaskbar()
        {
            // 작업 표시줄 핸들을 가져옴 (메인)
            IntPtr taskbarHandle = FindWindow("Shell_TrayWnd", null);

            // 현재 마우스 위치를 가져옴
            POINT cursorPos;
            GetCursorPos(out cursorPos);

            // 현재 마우스 위치의 윈도우 핸들을 가져옴
            IntPtr hwnd = WindowFromPoint(cursorPos);
            IntPtr rootOwner = GetAncestor(hwnd, GA_ROOTOWNER);

            // 메인 작업표시줄 확인
            if (rootOwner == taskbarHandle)
                return true;

            // 보조 모니터 작업표시줄 확인 (Shell_SecondaryTrayWnd)
            IntPtr secondaryTaskbar = FindWindow("Shell_SecondaryTrayWnd", null);
            while (secondaryTaskbar != IntPtr.Zero)
            {
                if (rootOwner == secondaryTaskbar)
                    return true;
                secondaryTaskbar = FindWindowEx(IntPtr.Zero, secondaryTaskbar, "Shell_SecondaryTrayWnd", null);
            }

            return false;
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam.ToInt32() == WM_MOUSEWHEEL)
            {
                try
                {
                    if (IsMouseOverTaskbar())
                    {
                        MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));

                        // mouseData의 상위 워드가 휠 델타값
                        int delta = (short)((hookStruct.mouseData >> 16) & 0xFFFF);

                        // 2.3 버전 방식: GetForegroundWindow()에 SendMessage
                        IntPtr foregroundWindow = GetForegroundWindow();

                        if (delta > 0)
                        {
                            // 스크롤 업 - 볼륨 증가
                            SendMessageW(foregroundWindow, WM_APPCOMMAND, foregroundWindow, (IntPtr)APPCOMMAND_VOLUME_UP);
                        }
                        else if (delta < 0)
                        {
                            // 스크롤 다운 - 볼륨 감소
                            SendMessageW(foregroundWindow, WM_APPCOMMAND, foregroundWindow, (IntPtr)APPCOMMAND_VOLUME_DOWN);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Mouse hook callback error: {ex.Message}");
                }
            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                Unhook();
                _disposed = true;
            }
        }

        ~LowLevelMouseHook()
        {
            Dispose(false);
        }

        #region Win32 API Declarations

        private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

        [StructLayout(LayoutKind.Sequential)]
        private struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int x;
            public int y;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(out POINT lpPoint);

        [DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint(POINT Point);

        [DllImport("user32.dll")]
        private static extern IntPtr GetAncestor(IntPtr hwnd, uint gaFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        #endregion
    }

    /// <summary>
    /// 마우스 휠 이벤트 인자 (하위 호환성을 위해 유지)
    /// </summary>
    public class MouseWheelEventArgs : EventArgs
    {
        public Point Location { get; }
        public int Delta { get; }

        public MouseWheelEventArgs(Point location, int delta)
        {
            Location = location;
            Delta = delta;
        }
    }
}
