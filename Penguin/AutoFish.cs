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
        int i = 0;

        #region FishingVariables

        int catchIconX = 800;
        int catchIconY = 800;
        int catchIconR = 1;
        int catchIconG = 2;
        int catchIconB = 3;

        int perfectBarX = 800;
        int perfectBarY = 800;
        int perfectBarR = 1;
        int perfectBarG = 2;
        int perfectBarB = 3;

                
        #endregion


        public void Start()
        {
            Console.Clear();
            BC.CyanLine(Ascii.Banner());
            SC.BlankLines(2);
            Console.ForegroundColor = ConsoleColor.Red;
            SC.WriteCenter("Penguin is *NOT* responsible for any actions taken against your account. Please type \"continue\" if you accept this risk...");

            //Loading Keyboard Driver and detecting input for Device ID;
          //Load();

            Console.ForegroundColor = ConsoleColor.Green;
            string response = Console.ReadLine();            
            if (response.ToLower() == "continue")
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
            using (var bar = new IndefiniteProgressBar('=', '-', 3, IndefiniteProgressBar.ProgressDirection.LeftToRight))
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
                      
            while(running)
            {
                //Cast the Fishing Line;
                input.SendKey(Keys.Space);

                //Wait for Catch To Appear (You can do this by Time or by Pixel Recognition)
                Color c = new Color();
                while (c.R != catchIconR && c.G != catchIconG && c.B != catchIconB)
                {
                    c = ScreenGrab.GetPixelColor(catchIconX, catchIconY);
                    action = $"R:{c.R},G:{c.G},B:{c.B}";
                    Thread.Sleep(100);
                }

                //Trigger occured Wait before sending Catch Command
                //Thread.Sleep(1000);
                
                //Hit Space to start catching the fish
                input.SendKey(Keys.Space);

                //Wait for blue bar to hit certain point for perfect catch
                while (c.R != perfectBarR && c.G != perfectBarG && c.B != perfectBarB)
                {
                    c = ScreenGrab.GetPixelColor(catchIconX, catchIconY);
                    action = $"R:{c.R},G:{c.G},B:{c.B}";
                    Thread.Sleep(100);
                }
            }

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
