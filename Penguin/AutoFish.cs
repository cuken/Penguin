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

namespace Penguin
{
    class AutoFish
    {
        bool running = true;
        Input input = new Input();
        int fishCaught = 0;
        string action = "Waiting to begin";
        System.Timers.Timer t1 = new System.Timers.Timer();

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
                
                Console.ForegroundColor = ConsoleColor.Cyan;
                action = "Casting";
                //Cast the Fishing Line;
                input.SendKey(Keys.Space);
                Thread.Sleep(5000);
                Console.ForegroundColor = ConsoleColor.Gray;
                action = "Waiting for bite";
                Thread.Sleep(30000);
                //Wait for Catch To Appear (You can do this by Time or by Pixel Recognition)
                Color c = new Color();
                while (!((c.R < catchIconR + catchLeeway) && (c.R > catchIconR - catchLeeway)) &&
                       !((c.G < catchIconG + catchLeeway) && (c.G > catchIconG - catchLeeway)) && 
                       !((c.B < catchIconB + catchLeeway) && (c.B > catchIconB - catchLeeway)))
                {
                    c = ScreenGrab.GetPixelColor(catchIconX, catchIconY);
                    action = $"Expecting:{catchIconR},{catchIconG},{catchIconB} Returning:{c.R},{c.G},{c.B}";
                    Thread.Sleep(50);
                }
                //Trigger occured Wait before sending Catch Command
                input.SendKey(Keys.Space);
                Console.WriteLine($"\n\nR:{c.R},G:{c.G},B:{c.B}");

                Console.ForegroundColor = ConsoleColor.Magenta;
                action = "Catching";

                //Color b1 = ScreenGrab.GetPixelColor(1088, 406);
                
                Color b3 = ScreenGrab.GetPixelColor(1023, 415);              
                
                
                //Color b3 = ScreenGrab.GetPixelColor(1088, 423);
                var watch = System.Diagnostics.Stopwatch.StartNew();
                while (!CheckBar(b3))
                {
                    //"B1-R:{b1.R},G:{b1.G},B:{b1.B}|B2-{b2.R},G:{b2.G},B:{b2.B}|
                    //action = $"B3-{b3.R},G:{b3.G},B:{b3.B}";
                    //b1 = ScreenGrab.GetPixelColor(1088, 406);
                    //b2 = ScreenGrab.GetPixelColor(1088, 415);                    
                    b3 = ScreenGrab.GetPixelColor(1088, 423);
                    watch.Stop();
                    action = watch.ElapsedMilliseconds.ToString();
                    watch.Reset();
                    watch.Start();
                }

                //Console.WriteLine($"\n\n\nR:{b1.R},G:{b1.G},B:{b1.B}");
                //Console.WriteLine($"\n\n\n\nR:{b2.R},G:{b2.G},B:{b2.B}");
                //Console.WriteLine($"\n\n\n\n\nR:{b3.R},G:{b3.G},B:{b3.B}");                

                //Wait for bar to be completely full
                //Thread.Sleep(catchTime);

                //Perfect catch the fish?!
                input.SendKey(Keys.Space);

                Console.ForegroundColor = ConsoleColor.Green;
                action = "Caught!";
                fishCaught++;
                //Wait for the loot dialog to come up
                Thread.Sleep(1050);

                action = "Looting";

                //Stop Input until we fix this later.
                Console.ReadKey();

            }

        }

        private bool CheckBar(Color b3)
        {
            bool result = false;
            int fuzzyness = 2;

            //if(b1.B > 130 && Math.Abs(b1.R - b1.B) > fuzzyness && Math.Abs(b1.G - b1.B) > fuzzyness)
            //{
            //    result =  true;
            //}
            //else if (b2.B > 130 && Math.Abs(b2.R - b2.B) > fuzzyness && Math.Abs(b2.G - b2.B) > fuzzyness)
            //{
            //    result = true;
            //}
            if (b3.B > 130 && Math.Abs(b3.R - b3.B) > fuzzyness && Math.Abs(b3.G - b3.B) > fuzzyness)
            {
                result = true;
            }

            return result;
        }

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
