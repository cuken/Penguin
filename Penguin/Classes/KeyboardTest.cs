using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Penguin.Classes
{
    class KeyboardTest
    {
        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);
        public static void Test()
        {
            Process[] notepads = Process.GetProcessesByName("BlackDesert64");
            if (notepads.Length == 0) return;
            if (notepads[0] != null)
            {
                IntPtr child = FindWindowEx(notepads[0].MainWindowHandle, new IntPtr(0), "Edit", null);
            }
        }
    }
}
