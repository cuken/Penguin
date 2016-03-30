using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Penguin.Classes
{
    //class FindChild
    //{

    //    [DllImport("user32.dll", SetLastError = true)]
    //static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    //IntPtr hWnd = (IntPtr)FindWindow("Blackdesert65", null);
    //[DllImport("user32.dll")]
    //[return: MarshalAs(UnmanagedType.Bool)]
    //static extern bool EnumChildWindows(IntPtr hwndParent, EnumWindowsProc lpEnumFunc, IntPtr lParam);

    //private List<IntPtr> GetChildWindows(IntPtr parent)
    //{
    //    List<IntPtr> result = new List<IntPtr>();
    //    GCHandle listHandle = GCHandle.Alloc(result);
    //    try
    //    {
    //        EnumWindowProc childProc = new EnumWindowProc(EnumWindow);
    //        EnumChildWindows(parent, childProc, GCHandle.ToIntPtr(listHandle));
    //    }
    //    finally
    //    {
    //        if (listHandle.IsAllocated)
    //            listHandle.Free();
    //    }
    //    return result;
    //}

    class FindChild
    {

        [DllImport("user32.dll", EntryPoint = "FindWindowEx",
        CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        public static void Test()
        {
            IntPtr appHandle = FindWindow(null, "Form1"); // P/Invoke
            Console.WriteLine("App handle = " + appHandle.ToString("X"));
            List<IntPtr> children = FindChild.GetAllChildrenWindowHandles(appHandle, 100);

            Console.WriteLine("Children handles are:");
            for (int i = 0; i < children.Count; ++i)
                Console.WriteLine(children[i].ToString("X"));
        }

        public static List<IntPtr> GetAllChildrenWindowHandles(IntPtr hParent, int maxCount)
        {
            List<IntPtr> result = new List<IntPtr>();
            int ct = 0;
            IntPtr prevChild = IntPtr.Zero;
            IntPtr currChild = IntPtr.Zero;
            while (true && ct < maxCount)
            {
                currChild = FindWindowEx(hParent, prevChild, null, null);
                if (currChild == IntPtr.Zero) break;
                result.Add(currChild);
                prevChild = currChild;
                ++ct;
            }
            return result;
        }
    }
}
