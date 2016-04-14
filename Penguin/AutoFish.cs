using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Interceptor;
using Penguin.HelperClasses;
using Spinnerino;
using System.Drawing;
using System.Timers;
using System.IO;
using Penguin.ImageProcessing;
using System.Diagnostics;
using System.Drawing.Imaging;
using ColorMine.ColorSpaces.Comparisons;
using ColorMine.ColorSpaces;
using Tesseract;

namespace Penguin
{
    class AutoFish
    {
        bool running = true;
        Input input = new Input();
        int fishCaught = 0;
        int minigameBarWaitCount = 0;
        string action = "Waiting to begin";
        System.Timers.Timer t1 = new System.Timers.Timer();
        bool perfectCatch = true;

        #region FishingVariables
        int catchLeeway = 2;

        int catchIconX = 1065;
        int catchIconY = 94;
        int catchIconR = 240;
        int catchIconG = 214;
        int catchIconB = 104;

        int catchTime = 600;

                
        #endregion


        public void Start()
        {
            Console.Clear();
            BC.CyanLine(Ascii.Banner());
            SC.BlankLines(2);
            Console.ForegroundColor = ConsoleColor.Red;
            SC.WriteCenter("Penguin is *NOT* responsible for any actions taken against your account. Please type \"c\" if you accept this risk...");

            //Loading Keyboard Driver and detecting input for Device ID;
            Load();

            Console.ForegroundColor = ConsoleColor.Green;
            string response = Console.ReadLine();            
            if (response.ToLower() == "c")
            {
                running = true;
                Console.Clear();
                BC.CyanLine(Ascii.Banner());
                SC.BlankLines(2);
                Console.ForegroundColor = ConsoleColor.White;
                SC.WriteCenter("Press 'X' to quit");
                SC.BlankLines(2);

                Thread fishingThread = new Thread(StartFishing);
                fishingThread.Start();

                Thread progressBar = new Thread(StartBar);
                progressBar.Start();

                ConsoleKey key = Console.ReadKey().Key;
                while (key != ConsoleKey.X)
                {
                    Console.WriteLine("Test");
                    key = Console.ReadKey().Key;
                }

                running = false;

                //Unloading Keyboard Driver
                UnLoad();
                Console.Clear();
                BC.CyanLine(Ascii.Banner());
            }
        }

        private void StartBar()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            using (var bar = new IndefiniteProgressBar('>', ' ', 5, IndefiniteProgressBar.ProgressDirection.LeftToRight))
            {
                while (running)
                {
                    bar.SetAction($"{action} | Caught: {fishCaught}");
                }
            }
        }

        private void StartFishing()
        {
            /*Fishing Steps...

            ASSUMPTIONS: User already has fishing pole equiped and is Facing Water

            1) Cast the Line by pressing Space;
            2) Wait for the Catch Icon to Appear
            3) Start the catch game by pressing Space;
            4) Wait for blue fillup bar to hit "sweet" spot.
            5) Press space to perfect catch the fish.

            */

            WindowHelper.SwitchWindow("BlackDesert64");
            Thread.Sleep(100);

                      
            while(running)
            {
                //Cast the Fishing Line;

                Console.ForegroundColor = ConsoleColor.Cyan;
                action = "Casting";
                input.SendKey(Keys.Space);
                Thread.Sleep(2500);

                //Wait for the fish to bite
                Console.ForegroundColor = ConsoleColor.Gray;
                action = "Waiting for bite";
                Thread.Sleep(15000);

                while(!WaitForBite())
                {
                    Thread.Sleep(10);
                }

                //Bite Detected, hit Space to start catch
                input.SendKey(Keys.Space);
                Console.ForegroundColor = ConsoleColor.Magenta;
                action = "Catching";

                //Trying for perfect catch!
                Thread.Sleep(1550);

                input.SendKey(Keys.Space);

                //Need to determine if we have a perfect catch or not....
                //Put in some kind of timer maybe...
                if(WaitForCatchBar())
                {
                    //CatchBarAppeared
                    //BEGIN OCR ROUTINE HERE
                    OCR();
                    
                }

                //Record the fish Catch
                Console.ForegroundColor = ConsoleColor.Green;
                action = "Caught!";
                fishCaught++;

                //Wait for the loot dialog to come up
                Thread.Sleep(GlobalSettings.Timer.lootDelay);
                action = "Looting";
                Loot();

                //Wait to recast
                Thread.Sleep(1000);
            }

        }

        private void OCR()
        {
            var c1 = ScreenGrab.GetPixelColor(GlobalSettings.OCR.colorPixel_X, GlobalSettings.OCR.colorPixel_Y);
            var bmpScreenshot = new Bitmap(GlobalSettings.OCR.ocrWidth, GlobalSettings.OCR.ocrHeight, PixelFormat.Format32bppArgb);
            
            //Change threshold by color found
            int threshold = CompareOCRColor(c1);

            var gfxScreenshot = Graphics.FromImage(bmpScreenshot);
            gfxScreenshot.CopyFromScreen(GlobalSettings.OCR.ocr_X, GlobalSettings.OCR.ocr_Y, 0, 0, bmpScreenshot.Size);
            var newBmp = new LockBitmap(bmpScreenshot);
            newBmp.LockBits();
            var myRgb = new Rgb { R = c1.R, B = c1.B, G = c1.G };
            for (int x = 0; x < newBmp.Width; x++)
            {
                for (int y = 0; y < newBmp.Height; y++)
                {
                    var pix = newBmp.GetPixel(x, y);
                    var rgb2 = new Rgb { R = pix.R, B = pix.B, G = pix.G };
                    var deltaE = myRgb.Compare(rgb2, new Cie1976Comparison());
                    if (deltaE > threshold)
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

            if(GlobalSettings.General.debug)
                newBmp.GetSourceBitmap().Save("e:\\workingonthistoday\\colorcorrected.tif");

            var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default);
            engine.SetVariable("tessedit_char_whitelist", "WASD");
            var page = engine.Process(newBmp.GetSourceBitmap(), PageSegMode.SingleLine);
            var result = page.GetText();
            page.Dispose();
            engine.Dispose();
            newBmp.GetSourceBitmap().Dispose();

            foreach(char c in result)
            {
                Thread.Sleep(20);
                switch(c)
                {
                    case 'W':
                        input.SendKey(Keys.W);
                        break;
                    case 'A':
                        input.SendKey(Keys.A);
                        break;
                    case 'S':
                        input.SendKey(Keys.S);
                        break;
                    case 'D':
                        input.SendKey(Keys.D);
                        break;
                    default:
                        break;
                }
            }
        }

        private int CompareOCRColor(Color c1)
        {
            int threshold = 0;
            var compare = new Rgb { R = c1.R, B = c1.B, G = c1.G };
            var gray = new Rgb {    R = GlobalSettings.Color.gray_R,    B = GlobalSettings.Color.gray_B,    G = GlobalSettings.Color.gray_G };
            var teal = new Rgb {    R = GlobalSettings.Color.teal_R,    B = GlobalSettings.Color.teal_B,    G = GlobalSettings.Color.teal_G };
            var purple = new Rgb {  R = GlobalSettings.Color.purple_R,  B = GlobalSettings.Color.purple_B,  G = GlobalSettings.Color.purple_G };
            var red = new Rgb {     R = GlobalSettings.Color.red_R,     B = GlobalSettings.Color.red_B,     G = GlobalSettings.Color.red_G };
            var green = new Rgb {   R = GlobalSettings.Color.green_R,   B = GlobalSettings.Color.green_B,   G = GlobalSettings.Color.green_G };
            var white = new Rgb {   R = GlobalSettings.Color.white_R,   B = GlobalSettings.Color.white_B,   G = GlobalSettings.Color.white_G };
                        
            var dG = compare.Compare(gray,      new Cie1976Comparison());
            var dT = compare.Compare(teal,      new Cie1976Comparison());
            var dP = compare.Compare(purple,    new Cie1976Comparison());
            var dR = compare.Compare(red,       new Cie1976Comparison());
            var dGr = compare.Compare(green,    new Cie1976Comparison());
            var dW = compare.Compare(white,     new Cie1976Comparison());

            var deltas = new[] { dG, dT, dP, dR, dGr, dW };

            switch(Array.IndexOf(deltas, deltas.Min()))
            {
                case 0:
                    threshold = GlobalSettings.Color.gray_Thresh;
                    break;
                case 1:
                    threshold = GlobalSettings.Color.teal_Thresh;
                    break;
                case 2:
                    threshold = GlobalSettings.Color.purple_Thresh;
                    break;
                case 3:
                    threshold = GlobalSettings.Color.red_Thresh;
                    break;
                case 4:
                    threshold = GlobalSettings.Color.green_Thresh;
                    break;
                case 5:
                    threshold = GlobalSettings.Color.white_Thresh;
                    break;
            }

            return threshold;

        }

        //private bool PerfectCatch()
        //{
        //    Color c1 = ScreenGrab.GetPixelColor(1050, 411);
        //    while (CheckCatch(c1) != true)
        //    {
        //        c1 = ScreenGrab.GetPixelColor(1050, 411);
        //    }
        //    return true;
        //}

        //private bool RegularCatch()
        //{
        //    Color c1 = ScreenGrab.GetPixelColor(1017, 404);
        //    while(CheckCatch(c1) != true)
        //    {
        //        c1 = ScreenGrab.GetPixelColor(1017, 404);
        //    }
        //    return true;
        //}

        private bool WaitForBite()
        {
            Color c = new Color();
            while (!((c.R < GlobalSettings.Catch.catchIcon_R + GlobalSettings.Catch.catchIcon_Fuzzy) && (c.R > GlobalSettings.Catch.catchIcon_R - GlobalSettings.Catch.catchIcon_Fuzzy)) &&
                   !((c.G < GlobalSettings.Catch.catchIcon_G + GlobalSettings.Catch.catchIcon_Fuzzy) && (c.G > GlobalSettings.Catch.catchIcon_G - GlobalSettings.Catch.catchIcon_Fuzzy)) &&
                   !((c.B < GlobalSettings.Catch.catchIcon_B + GlobalSettings.Catch.catchIcon_Fuzzy) && (c.B > GlobalSettings.Catch.catchIcon_B - GlobalSettings.Catch.catchIcon_Fuzzy)))
            {
                c = ScreenGrab.GetPixelColor(catchIconX, catchIconY);
                //action = $"Expecting:{catchIconR},{catchIconG},{catchIconB} Returning:{c.R},{c.G},{c.B}";
                Thread.Sleep(50);
            }
            return true;
        }


        private bool WaitForCatchBar()
        {
            
            Color c1 = ScreenGrab.GetPixelColor(1017, 404);
            Color c2 = ScreenGrab.GetPixelColor(1077, 404);
            Color c3 = ScreenGrab.GetPixelColor(1024, 425);

            while (CheckBar(c1) != true || CheckBar(c2) != true || CheckBar(c3) != true)
            {
                minigameBarWaitCount++;
                c1 = ScreenGrab.GetPixelColor(1017, 404);
                c2 = ScreenGrab.GetPixelColor(1077, 404);
                c3 = ScreenGrab.GetPixelColor(1024, 425);
                Thread.Sleep(10);
                if(minigameBarWaitCount > 20)
                {
                    return false;
                }
            }
            return true;
        }


        private void Loot()
        {
            //Add in logic later to determine the quality of the catch. For now, loot everything.
            input.SendKey(Keys.R);
        }

        private bool CheckBar(Color c)
        {
            if(c.R > 200 && c.G > 200 && c.B > 200)
            {
                return true;
            }
            else
            {
                return false;
            }            
        }

        private bool CheckCatch(Color c)
        {
            if(c.B > c.R + 50 && c.B > c.G)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //private bool CheckBar(Color c)
        //{
        //    bool result = false;
        //    int fuzzyness = 2;

        //    //if(b1.B > 130 && Math.Abs(b1.R - b1.B) > fuzzyness && Math.Abs(b1.G - b1.B) > fuzzyness)
        //    //{
        //    //    result =  true;
        //    //}
        //    //else if (b2.B > 130 && Math.Abs(b2.R - b2.B) > fuzzyness && Math.Abs(b2.G - b2.B) > fuzzyness)
        //    //{
        //    //    result = true;
        //    //}
        //    if (c.B > 130 && Math.Abs(c.R - c.B) > fuzzyness && Math.Abs(c.G - c.B) > fuzzyness)
        //    {
        //        result = true;
        //    }

        //    return result;
        //}

        private void Test()
        {
            Console.WriteLine("send input to deduce keyboard id");
            Console.ReadLine();

            //WindowsAPI.SwitchWindow(WindowHandle);
            WindowHelper.SwitchWindow("notepad");
            Thread.Sleep(2500);

            input.KeyPressDelay = 10;
            input.SendKey(Keys.Enter);
            Thread.Sleep(500);
            input.SendText("");
            Thread.Sleep(500);
            input.SendKey(Keys.Enter);
            //input.SendKeys(Keys.Space);

        }

        private void Load()
        {
            input.KeyboardFilterMode = KeyboardFilterMode.All;
            input.Load();
            input.KeyPressDelay = 10;
        }

        private void UnLoad()
        {
            input.Unload();
        }
    }
}
