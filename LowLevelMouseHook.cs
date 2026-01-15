using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace Freight
{
    /// <summary>
    /// 마우스 이벤트 인자 클래스
    /// </summary>
    public class MouseHookEventArgs : EventArgs
    {
        public Point Location { get; }
        public bool Handled { get; set; }

        public MouseHookEventArgs(Point location)
        {
            Location = location;
            Handled = false;
        }
    }

    /// <summary>
    /// 저수준 마우스 후킹 클래스 - 작업표시줄 위에서 스크롤로 볼륨 조절 + 제스처 지원
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

        // 마우스 버튼 및 이동 메시지
        private const int WM_MOUSEMOVE = 0x0200;
        private const int WM_RBUTTONDOWN = 0x0204;
        private const int WM_RBUTTONUP = 0x0205;

        private static LowLevelMouseProc _proc;
        private static IntPtr _hookID = IntPtr.Zero;
        private bool _disposed = false;

        // 제스처 관련 이벤트
        public event EventHandler<MouseHookEventArgs> RightButtonDown;
        public event EventHandler<MouseHookEventArgs> RightButtonUp;
        public event EventHandler<MouseHookEventArgs> MouseMove;

        // 우클릭 컨텍스트 메뉴 억제 플래그 (외부에서 설정 가능)
        public bool SuppressRightClick { get; set; }

        // 우클릭 상태 추적
        private static bool isRightButtonDown = false;
        public bool IsRightButtonDown => isRightButtonDown;

        // 제스처 감지를 위한 시작점 및 이동 거리 추적
        private static Point rightButtonDownPoint;
        private static double totalMovementDistance = 0;
        private static Point lastMovePoint;
        private const double MIN_GESTURE_DISTANCE = 50.0;  // 제스처로 인식할 최소 이동 거리

        // 인스턴스 참조 (static callback에서 사용)
        private static LowLevelMouseHook _instance;

        // SimulateRightClick에서 보낸 이벤트 구분용 마커
        private static readonly IntPtr SIMULATED_CLICK_MARKER = new IntPtr(0x12345678);

        public LowLevelMouseHook()
        {
            _proc = HookCallback;
            _instance = this;
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
        /// 수동으로 우클릭 이벤트 전송 (컨텍스트 메뉴 표시용)
        /// </summary>
        private static void SimulateRightClick(Point location)
        {
            INPUT[] inputs = new INPUT[2];

            // Right button down
            inputs[0] = new INPUT
            {
                type = INPUT_MOUSE,
                mi = new MOUSEINPUT
                {
                    dx = 0,
                    dy = 0,
                    mouseData = 0,
                    dwFlags = MOUSEEVENTF_RIGHTDOWN,
                    time = 0,
                    dwExtraInfo = SIMULATED_CLICK_MARKER
                }
            };

            // Right button up
            inputs[1] = new INPUT
            {
                type = INPUT_MOUSE,
                mi = new MOUSEINPUT
                {
                    dx = 0,
                    dy = 0,
                    mouseData = 0,
                    dwFlags = MOUSEEVENTF_RIGHTUP,
                    time = 0,
                    dwExtraInfo = SIMULATED_CLICK_MARKER
                }
            };

            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));
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
            if (nCode >= 0)
            {
                int msg = wParam.ToInt32();

                try
                {
                    MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));

                    // GetCursorPos를 사용하여 논리적 좌표 획득 (DPI 인식 설정에 맞는 좌표)
                    // hookStruct.pt는 항상 물리적 좌표를 반환하므로 DPI 스케일링 환경에서 문제 발생
                    POINT cursorPt;
                    GetCursorPos(out cursorPt);
                    Point location = new Point(cursorPt.x, cursorPt.y);

                    // 우리가 SendInput으로 보낸 이벤트는 무시 (무한 루프 방지)
                    if (hookStruct.dwExtraInfo == SIMULATED_CLICK_MARKER)
                    {
                        return CallNextHookEx(_hookID, nCode, wParam, lParam);
                    }

                    // 마우스 휠 처리 (작업표시줄 볼륨)
                    if (msg == WM_MOUSEWHEEL)
                    {
                        if (IsMouseOverTaskbar())
                        {
                            int delta = (short)((hookStruct.mouseData >> 16) & 0xFFFF);
                            IntPtr foregroundWindow = GetForegroundWindow();

                            if (delta > 0)
                            {
                                SendMessageW(foregroundWindow, WM_APPCOMMAND, foregroundWindow, (IntPtr)APPCOMMAND_VOLUME_UP);
                            }
                            else if (delta < 0)
                            {
                                SendMessageW(foregroundWindow, WM_APPCOMMAND, foregroundWindow, (IntPtr)APPCOMMAND_VOLUME_DOWN);
                            }
                        }
                    }
                    // 우클릭 다운 - 모든 앱에서 차단 (드래그 박스 방지)
                    else if (msg == WM_RBUTTONDOWN)
                    {
                        isRightButtonDown = true;
                        rightButtonDownPoint = location;
                        lastMovePoint = location;
                        totalMovementDistance = 0;

                        var args = new MouseHookEventArgs(location);
                        _instance?.RightButtonDown?.Invoke(_instance, args);

                        // 모든 앱에서 RButtonDown 차단
                        // 제스처 아니면 RButtonUp에서 수동으로 우클릭 전송
                        return (IntPtr)1;
                    }
                    // 우클릭 업
                    else if (msg == WM_RBUTTONUP)
                    {
                        bool wasRightButtonDown = isRightButtonDown;
                        isRightButtonDown = false;

                        // 이벤트 핸들러 호출 (제스처 실행)
                        var args = new MouseHookEventArgs(location);
                        _instance?.RightButtonUp?.Invoke(_instance, args);

                        // 제스처가 있었는지 확인 (이동 거리 또는 외부 플래그)
                        bool gesturePerformed = totalMovementDistance >= MIN_GESTURE_DISTANCE ||
                                                (_instance?.SuppressRightClick == true);

                        // 플래그 초기화
                        if (_instance != null)
                        {
                            _instance.SuppressRightClick = false;
                        }
                        double movedDistance = totalMovementDistance;
                        totalMovementDistance = 0;

                        if (wasRightButtonDown)
                        {
                            if (gesturePerformed)
                            {
                                // 제스처 수행됨 - 컨텍스트 메뉴 억제
                                return (IntPtr)1;
                            }
                            else
                            {
                                // 제스처 아님 - 수동으로 우클릭 전송하여 컨텍스트 메뉴 표시
                                SimulateRightClick(location);
                                return (IntPtr)1; // 원본 이벤트는 차단
                            }
                        }
                    }
                    // 마우스 이동
                    else if (msg == WM_MOUSEMOVE)
                    {
                        if (isRightButtonDown)
                        {
                            // 이동 거리 누적
                            double dx = location.X - lastMovePoint.X;
                            double dy = location.Y - lastMovePoint.Y;
                            totalMovementDistance += Math.Sqrt(dx * dx + dy * dy);
                            lastMovePoint = location;

                            var args = new MouseHookEventArgs(location);
                            _instance?.MouseMove?.Invoke(_instance, args);
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

        // SendInput 관련 구조체 및 상수
        private const int INPUT_MOUSE = 0;
        private const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const uint MOUSEEVENTF_RIGHTUP = 0x0010;

        [StructLayout(LayoutKind.Sequential)]
        private struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct INPUT
        {
            public int type;
            public MOUSEINPUT mi;
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

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
