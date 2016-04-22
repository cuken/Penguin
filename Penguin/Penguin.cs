using System;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using Penguin.HelperClasses;
using Rhino.Licensing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using System.Collections.Generic;

namespace Penguin
{
    public class Penguin
    {
        public static Penguin p;
        public static GlobalSettings settings;
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
            Console.Title = $"Penguin - {Application.ProductVersion}";
            BC.CyanLine(Ascii.Banner());
            Console.ForegroundColor = ConsoleColor.Gray;
            SC.BlankLines(1);
            SC.WriteCenter($"Version {Application.ProductVersion} - Alpha");
            SC.BlankLines(3);
            try
            {
                if(Update.Update.CheckVersion())
                {
                    Console.Write("A new version of Penguin is available, would you like to update now? (y/n): ");
                    string response = Console.ReadLine();
                    if (response.ToLower() == "y") 
                    {
                        Update.Update.DownloadUpdate();
                        Update.Update.InstallUpdate();                        
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            try
            {
                GlobalSettings.Load();

            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Unable to locate settings file in {Environment.CurrentDirectory}\\config - Please make sure you have a settings.json file present!");
                Console.ReadKey();
                Environment.Exit(99);
            }
            try
            {
                var publicKey = File.ReadAllText(@".\config\publicKey.xml");
                new LicenseValidator(publicKey, @".\config\license.xml")
                .AssertValidLicense();
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"You do not have a valid license file in {Environment.CurrentDirectory}\\config - Please make sure you have both your public key and license.xml file present!");
                Console.ReadKey();
                Environment.Exit(20);
            }
            try
            {
                File.Exists(@"C:\Windows\System32\drivers\keyboard.sys");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            if (!File.Exists(@"C:\Windows\System32\drivers\keyboard.sys"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Unable to find low level keyboard driver on this machine. Please reinstall the driver from the Penguin directory using an administrative account!");
                Console.ReadKey();
                Environment.Exit(10);
            }

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
    }    
}
