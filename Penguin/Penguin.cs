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
using Newtonsoft.Json;
using System.Drawing.Imaging;
using ColorMine;
using Penguin.ImageProcessing;
using ColorMine.ColorSpaces;
using ColorMine.ColorSpaces.Comparisons;
using Tesseract;

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
            Console.Title = "Penguin - 0.0.1";
            BC.CyanLine(Ascii.Banner());
            Console.ForegroundColor = ConsoleColor.Gray;
            SC.BlankLines(1);
            SC.WriteCenter("Version 0.0.1 Alpha");
            SC.BlankLines(3);
            Console.ForegroundColor = ConsoleColor.Green;

            if (File.Exists("settings.json"))
                settings = JsonConvert.DeserializeObject<GlobalSettings>(File.ReadAllText("settings.json"));
            else
                settings = new GlobalSettings();
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
            
            var bmpScreenshot = new Bitmap(358, 25, PixelFormat.Format32bppArgb);
            int threshold = 20;
            var gfxScreenshot = Graphics.FromImage(bmpScreenshot);
            gfxScreenshot.CopyFromScreen(781, 502, 0, 0, new Size(358, 42));
            var newBmp = new LockBitmap(bmpScreenshot);
            newBmp.LockBits();
            sw.Start();
            var c1 = newBmp.GetPixel(21,7);
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            var myRgb = new Rgb { R = c1.R, B = c1.B, G = c1.G };
            for(int x = 0; x < newBmp.Width; x++)
            {
                for (int y = 0; y < newBmp.Height; y++)
                {
                    var pix = newBmp.GetPixel(x, y);
                    var rgb2 = new Rgb { R = pix.R, B = pix.B, G = pix.G };
                    var deltaE = myRgb.Compare(rgb2, new Cie1976Comparison());
                    if(deltaE > threshold)
                    {
                        newBmp.SetPixel(x, y, Color.White);
                    }
                    else
                    {
                        newBmp.SetPixel(x, y, Color.Black);
                    }
                }
            }

            newBmp.UnlockBits();
            
            newBmp.GetSourceBitmap().Save("e:\\workingonthistoday\\colorcorrected.tif");
            

            var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default);
            engine.SetVariable("tessedit_char_whitelist", "WASD");
            var page = engine.Process(newBmp.GetSourceBitmap() , PageSegMode.SingleLine);
            var result = page.GetText();
            page.Dispose();
            engine.Dispose();
            newBmp.GetSourceBitmap().Dispose();
            Console.WriteLine(result);

        }
    }    
}
