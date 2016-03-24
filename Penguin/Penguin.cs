using System;
using Penguin.Classes;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Timers;
using System.Drawing;

namespace Penguin
{
    public class Penguin
    {

        bool alive = true;
        System.Timers.Timer t = new System.Timers.Timer();
        PerfectCatch pc = new PerfectCatch();
        int imageNumb = 0;

        static void Main(string[] args) => new Penguin().Start(args);

        private void Start(string[] args)
        {
            //Set Console Title:
            Console.Title = "Penguin - 0.0.1";                   
            BC.CyanLine(Banner());
            Console.ForegroundColor = ConsoleColor.Gray;
            SC.BlankLines(1);
            SC.WriteCenter("Version 0.0.1 Alpha");
            SC.BlankLines(3);
            Console.ForegroundColor = ConsoleColor.Green;

            t.Interval = 5000;
            t.AutoReset = true;
            t.Elapsed += T_Elapsed;

            Menu();

            //Cleanup Tasks...
            //End of program...
        }

        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            ScreenGrab.SavePicture(0,0,800,600, @"e:\penguin\test\" + imageNumb + ".png");
            imageNumb++;
        }

        private void AFKFish()
        {
            
        }        

        private void Menu()
        {
            string input = "";

            while(alive)
            {
                SC.BlankLines(1);
                BC.Green(">");
                Console.ForegroundColor = ConsoleColor.White;
                input = Console.ReadLine();
                switch(input.ToLower())
                {
                    case "exit":
                    case "quit":
                    case "leave":
                    case "bye":
                        return;
                    case "afk":
                    case "autoFish":
                        AFKFish();
                        break;
                    case "assist":
                    case "perfect":
                         pc.Start();
                        break;
                    case "start":
                        Start();
                        break;
                    case "stop":
                        Stop();
                        break;
                    case "getcolor":
                        GetColor();
                        break;
                    default:
                        break;
                }
            }
        }

        private void GetColor()
        {
            var tmp = ScreenGrab.GetBMP(0, 0, 100, 100);
            Console.WriteLine($"R:{tmp.GetPixel(50, 50).R} | G:{tmp.GetPixel(50, 50).G} | B:{tmp.GetPixel(50, 50).B}");
        }

        private void Stop()
        {
            t.Stop();
        }

        private void Start()
        {
            t.Start();
        }

        public static string Banner()
        {
            return @"                      ____                        _       " + "\n" +
                   @"                     |  _ \ ___ _ __   __ _ _   _(_)_ __  " + "\n" +
                   @"                     | |_) / _ \ '_ \ / _` | | | | | '_ \ " + "\n" +
                   @"                     |  __/  __/ | | | (_| | |_| | | | | |" + "\n" +
                   @"                     |_|   \___|_| |_|\__, |\__,_|_|_| |_|" + "\n" +
                   @"                                      |___/               ";
        }

    }
}
