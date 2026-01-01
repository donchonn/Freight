using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Freight
{
    /// <summary>
    /// 저수준 키보드 후킹 클래스
    /// </summary>
    public class LowLevelKeyboardHook
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;

        private LowLevelKeyboardProc _proc;
        private IntPtr _hookID = IntPtr.Zero;

        // 수정자 키 상태 추적
        public bool IsCtrlPressed { get; private set; }
        public bool IsShiftPressed { get; private set; }

        public event KeyEventHandler KeyDown;
        public event KeyEventHandler KeyUp;

        public LowLevelKeyboardHook()
        {
            _proc = HookCallback;
        }

        public void Hook()
        {
            _hookID = SetHook(_proc);
        }

        public void Unhook()
        {
            if (_hookID != IntPtr.Zero)
            {
                UnhookWindowsHookEx(_hookID);
                _hookID = IntPtr.Zero;
            }
        }

        private IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                Keys key = (Keys)vkCode;
                bool handled = false;

                if (wParam == (IntPtr)WM_KEYDOWN)
                {
                    // 수정자 키 상태 업데이트
                    if (key == Keys.LControlKey || key == Keys.RControlKey || key == Keys.ControlKey)
                        IsCtrlPressed = true;
                    if (key == Keys.LShiftKey || key == Keys.RShiftKey || key == Keys.ShiftKey)
                        IsShiftPressed = true;

                    KeyEventArgs args = new KeyEventArgs(key);
                    KeyDown?.Invoke(this, args);
                    handled = args.Handled;
                }
                else if (wParam == (IntPtr)WM_KEYUP)
                {
                    // 수정자 키 상태 업데이트
                    if (key == Keys.LControlKey || key == Keys.RControlKey || key == Keys.ControlKey)
                        IsCtrlPressed = false;
                    if (key == Keys.LShiftKey || key == Keys.RShiftKey || key == Keys.ShiftKey)
                        IsShiftPressed = false;

                    KeyEventArgs args = new KeyEventArgs(key);
                    KeyUp?.Invoke(this, args);
                    handled = args.Handled;
                }

                // 처리된 키는 다른 앱에 전달하지 않음
                if (handled)
                {
                    return (IntPtr)1;
                }
            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}
