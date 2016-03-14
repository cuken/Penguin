using System;
using Penguin.Classes;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Penguin
{
    public class Penguin
    {

        bool alive = true;
        PerfectCatch pc = new PerfectCatch();

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

            Menu();

            //Cleanup Tasks...
            //End of program...
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
                    default:
                        break;
                }
            }
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
