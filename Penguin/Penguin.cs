using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Spinnerino;
using Penguin.HelperClasses;
using System.Drawing;

namespace Penguin
{
    public class Penguin
    {
        static Penguin p;
        //AutoFish fish = new AutoFish();

        static bool exitSystem = false;

        #region Trap application termination
        [DllImport("Kernel32")]
        private static extern bool SetConsoleCtrlHandler(EventHandler handler, bool add);

        private delegate bool EventHandler(CtrlType sig);
        static EventHandler _handler;

        enum CtrlType
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT = 1,
            CTRL_CLOSE_EVENT = 2,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT = 6
        }

        private static bool Handler(CtrlType sig)
        {
            Console.Clear();
            BC.RedLine("Exiting system due to external CTRL-C, or process kill, or shutdown", ConsoleColor.White);
            
            Thread.Sleep(80);

            Console.WriteLine("Cleanup complete");

            //allow main to run off
            exitSystem = true;

            //shutdown right away so there are no lingering threads
            Environment.Exit(-1);

            return true;
        }
        #endregion

        static void Main(string[] args)
        {
            _handler += new EventHandler(Handler);
            SetConsoleCtrlHandler(_handler, true);
            p = new Penguin();
            p.Start();
            
            while (!exitSystem)
            {
                Thread.Sleep(500);
            }
        }

        private void Start()
        {
            Console.Title = "Penguin - 0.0.1";
            BC.CyanLine(Ascii.Banner());
            Console.ForegroundColor = ConsoleColor.Gray;
            SC.BlankLines(1);
            SC.WriteCenter("Version 0.0.1 Alpha");
            SC.BlankLines(3);
            Console.ForegroundColor = ConsoleColor.Green;
            Menu();
        }

        private void Menu()
        {
            string input = "";

            while (!exitSystem)
            {
                try
                {
                    SC.BlankLines(1);
                    BC.Green(">");
                    Console.ForegroundColor = ConsoleColor.White;
                    input = Console.ReadLine();
                    switch (input.ToLower())
                    {
                        case "exit":
                        case "quit":
                        case "leave":
                        case "bye":
                            exitSystem = true;
                            break;
                        case "start":
                        case "go":
                        //case "begin":
                        //    fish.Start();
                        //    break;
                        case "test":
                            test();
                            break;
                        default:
                            break;
                    }
                }
                catch(Exception ex)
                {
                    BC.RedLine(ex.Message);
                }
            }
        }

        [DllImport("gdi32.dll")]
        private static extern int BitBlt(IntPtr srchDC, int srcX, int srcY, int srcW, int srcH, IntPtr desthDC, int destX, int destY, int op);

        private void test()
        {
            runTests();
        }

        private void runTests()
        {
            IntPtr hWnd = IntPtr.Zero;
            foreach (Process pList in Process.GetProcesses())
            {
                if (pList.MainWindowTitle.Contains("notepad"))
                {
                    hWnd = pList.MainWindowHandle;
                }
            }
            var watch = System.Diagnostics.Stopwatch.StartNew();
            long result1 = 0;
            for (int i = 0; i < 1000; i++)
            {
                watch.Start();
                ScreenGrab.GDI(hWnd, 500, 500);
                ScreenGrab.GDI(hWnd, 500, 500);
                ScreenGrab.GDI(hWnd, 500, 500);
                watch.Stop();
                result1 += watch.ElapsedMilliseconds;
                watch.Reset();
            }

            result1 = result1 / 1000;

            long result2 = 0;
            for (int i = 0; i < 1000; i++)
            {
                watch.Start();
                ScreenGrab.GetPixelColor(500, 500);
                ScreenGrab.GetPixelColor(500, 500);
                ScreenGrab.GetPixelColor(500, 500);
                watch.Stop();
                result2 += watch.ElapsedMilliseconds;
                watch.Reset();
            }

            result2 = result2 / 1000;

            long result3 = 0;
            for (int i = 0; i < 1000; i++)
            {
                watch.Start();
                ScreenGrab.GetScreen(500, 500, 1, 1);
                ScreenGrab.GetScreen(500, 500, 1, 1);
                ScreenGrab.GetScreen(500, 500, 1, 1);
                watch.Stop();
                result3 += watch.ElapsedMilliseconds;
                watch.Reset();
            }

            result3 = result3 / 1000;

            Console.WriteLine($"T1:{result1}\nT2:{result2}\nT3:{result3}");

        }
    }    
}
