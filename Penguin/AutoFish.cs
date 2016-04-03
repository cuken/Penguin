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

                //Wait for Catch minigame bar to appear
                Console.ForegroundColor = ConsoleColor.Magenta;
                action = "Catching";

                while(!WaitForCatchBar())
                {
                    Thread.Sleep(10);
                }

                //Bar Found!
                //Conditional logic of perfect catch versus non?

                if(perfectCatch)
                {
                    //Attempt to catch the fish "perfectly"
                    while (!PerfectCatch())
                    {
                        Thread.Sleep(10);
                    }
                }
                else
                {
                    //Catch the fish in the blue, play fish minigame
                    while (!RegularCatch())
                    {
                        Thread.Sleep(10);
                    }
                }
                input.SendKey(Keys.Space);

                //Record the fish Catch
                Console.ForegroundColor = ConsoleColor.Green;
                action = "Caught!";
                fishCaught++;

                //Wait for the loot dialog to come up
                Thread.Sleep(3000);
                action = "Looting";
                Loot();

                //Wait to recast
                Thread.Sleep(1000);               
            }

        }

        private bool PerfectCatch()
        {
            Color c1 = ScreenGrab.GetPixelColor(1050, 411);
            while (CheckCatch(c1) != true)
            {
                c1 = ScreenGrab.GetPixelColor(1050, 411);
            }
            return true;
        }

        private bool RegularCatch()
        {
            Color c1 = ScreenGrab.GetPixelColor(1017, 404);
            while(CheckCatch(c1) != true)
            {
                c1 = ScreenGrab.GetPixelColor(1017, 404);
            }
            return true;
        }

        private bool WaitForBite()
        {            
            Color c = new Color();
            while (!((c.R < catchIconR + catchLeeway) && (c.R > catchIconR - catchLeeway)) &&
                   !((c.G < catchIconG + catchLeeway) && (c.G > catchIconG - catchLeeway)) &&
                   !((c.B < catchIconB + catchLeeway) && (c.B > catchIconB - catchLeeway)))
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

            while(CheckBar(c1) != true || CheckBar(c2) != true || CheckBar(c3) != true)
            {
                c1 = ScreenGrab.GetPixelColor(1017, 404);
                c2 = ScreenGrab.GetPixelColor(1077, 404);
                c3 = ScreenGrab.GetPixelColor(1024, 425);
                Thread.Sleep(10);
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
