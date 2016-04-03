﻿using System;
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
        AutoFish fish = new AutoFish();

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
                        case "begin":
                            fish.Start();
                            break;
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
        private void test()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Color c1 = ScreenGrab.GetPixelColor(1017, 404);
            Color c2 = ScreenGrab.GetPixelColor(1077, 404);
            Color c3 = ScreenGrab.GetPixelColor(1024, 425);

            while (CheckBar(c1) != true || CheckBar(c2) != true || CheckBar(c3) != true)
            {
                c1 = ScreenGrab.GetPixelColor(1017, 404);
                c2 = ScreenGrab.GetPixelColor(1077, 404);
                c3 = ScreenGrab.GetPixelColor(1024, 425);
                Thread.Sleep(10);
            }
            sw.Stop();
            BC.GreenLine("Found it!");
            Console.WriteLine(sw.ElapsedMilliseconds);

            while (!PerfectCatch())
            {
                Thread.Sleep(10);
            }

            Console.WriteLine("HIT THE BUTTON!");
        }

        private bool CheckBar(Color c)
        {
            if (c.R > 200 && c.G > 200 && c.B > 200)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool PerfectCatch()
        {
            Color c1 = ScreenGrab.GetPixelColor(1080, 411);
            //Color c2 = ScreenGrab.GetPixelColor(1017, 404);
            //while (CheckCatch(c1) != true || CheckCatch(c2) != true)
            while (CheckCatch(c1) != true)
            {
                c1 = ScreenGrab.GetPixelColor(1080, 411);
                //c2 = ScreenGrab.GetPixelColor(1017, 404);
            }
            return true;
        }
        private bool CheckCatch(Color c)
         {
            if (c.B > c.R + 30 && c.B > c.G)
            {
                return true;
            }
            else
            {
                Console.WriteLine(c.R + "," + c.G + "," + c.B);
                return false;
            }
        }
    }
}
