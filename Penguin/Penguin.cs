using System;
using Penguin.Classes;
using System.IO;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using System.Diagnostics;
using Interceptor;
using System.Runtime.InteropServices;

namespace Penguin
{
    public class Penguin
    {
        static Penguin p;
        PerfectCatch pc = new PerfectCatch();
        Input input = new Input();

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
            Console.WriteLine("Exiting system due to external CTRL-C, or process kill, or shutdown");

            p.UnloadKeyboard();
            Thread.Sleep(80);

            Console.WriteLine("Cleanup complete");

            //allow main to run off
            exitSystem = true;

            //shutdown right away so there are no lingering threads
            Environment.Exit(-1);

            return true;
        }


        private void UnloadKeyboard()
        {
            input.Unload();
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

            input.KeyboardFilterMode = KeyboardFilterMode.All;
            input.Load();
            input.KeyPressDelay = 20;

            //Set Console Title:
            Console.Title = "Penguin - 0.0.1";
            BC.CyanLine(Banner());
            Console.ForegroundColor = ConsoleColor.Gray;
            SC.BlankLines(1);
            SC.WriteCenter("Version 0.0.1 Alpha");
            SC.BlankLines(3);
            Console.ForegroundColor = ConsoleColor.Green;
            Menu();



            //Cleanup Tasks...
            //End of program...
        }


        private void AFKFish()
        {
            Process[] processes = Process.GetProcessesByName("BlackDesert64");

            if (processes.Length == 0)
                throw new Exception("Could not find the Warhammer process; is Warhammer running?");
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
                        case "afk":
                        case "autoFish":
                            AFKFish();
                            break;
                        case "assist":
                        case "perfect":
                            //CatchAssist.Start();
                            break;
                        case "test":
                            Test();
                            break;
                        default:
                            break;
                    }
                }
                catch { }
            }
        }

        private void Test()
        {
            Input input = new Input();
            input.KeyboardFilterMode = KeyboardFilterMode.All;
            input.Load();

            //Process[] processes = Process.GetProcessesByName("BlackDesert64");

            //if (processes.Length == 0)
            //{
            //    BC.RedLine("Could not find the BlackDesert process; is BlackDesert running?");
            //    return;
            //}

            //IntPtr WindowHandle = processes[0].MainWindowHandle;

            Console.WriteLine("send input to deduce keyboard id");
            Console.ReadLine();

            //WindowsAPI.SwitchWindow(WindowHandle);
            WindowHelper.SwitchWindow("notepad");
            Thread.Sleep(2500);

            input.KeyPressDelay = 10;
            input.SendKey(Keys.Enter);
            Thread.Sleep(500);
            input.SendText("MM, I love you so much and I can't wait to have fun with you in Las Vegas. Love HB and his PENGUIN!");
            Thread.Sleep(500);
            input.SendKey(Keys.Enter);
            //input.SendKeys(Keys.Space);

            input.Unload();

        }

        public static string Banner()
        {
            return @" ____                        _       " + "\n" +
                   @"|  _ \ ___ _ __   __ _ _   _(_)_ __  " + "\n" +
                   @"| |_) / _ \ '_ \ / _` | | | | | '_ \ " + "\n" +
                   @"|  __/  __/ | | | (_| | |_| | | | | |" + "\n" +
                   @"|_|   \___|_| |_|\__, |\__,_|_|_| |_|" + "\n" +
                   @"                 |___/               ";
        }

    }
}
