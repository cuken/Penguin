using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Threading;

namespace Penguin.Classes
{
    class CatchAssist
    {
        static bool init = false;
        static int mouseX_Space = 0;
        static int mouseY_Space = 0;
        static int mouseX_R = 0;
        static int mouseY_R = 0;
        static IntPtr bdoHandle;
        static string penguin;

        static Spinner spinner = new Spinner("dashes", 0, 0, 100);

        //TIMERS ADJUST AS NEEDED
        static int catchTimer = 1750; //MostImportant!
        static int switchTimer = 800;
        static int fishCaughtTimer = 5000;
        static int lootTimer = 2000;
        static bool cont = true;

        public static void Start()
        {
            Init();

            BC.Red("Press any key to begin.");
            Console.ReadKey();
            while (cont)
            {
                Console.Clear();
                BC.CyanLine(Penguin.Banner());
                SC.BlankLines(4);
                BC.GreenLine("Perfect Catch Mode!");
                SC.BlankLines(2);
                BC.WhiteLine("Press AnyKey when BDO shows a fish is hooked.");
                BC.WhiteLine("Press 'Shift+F3' to quit");
                spinner.Start();
                Console.ReadKey();
                BC.DarkBlue("Switching to BDO");
                WindowsAPI.SwitchWindow(bdoHandle);
                Thread.Sleep(switchTimer);
                BC.DarkBlue($"Moving mouse to {mouseX_Space}|{mouseY_Space}");
                Thread.Sleep(50);
                Cursor.Position = new Point(mouseX_Space, mouseY_Space);
                Mouse.SendLeftClick();
                Thread.Sleep(catchTimer); //MOST IMPORTANT
                BC.DarkBlue($"Moving mouse to {mouseX_Space}|{mouseY_Space}");
                Thread.Sleep(50);
                Cursor.Position = new Point(mouseX_Space, mouseY_Space);
                Mouse.SendLeftClick();
                //Mouse.SendLeftClick(mouseX_Space, mouseY_Space);
                Thread.Sleep(fishCaughtTimer);
                BC.DarkBlue("Sending r");
                BC.DarkBlue($"Moving mouse to {mouseX_R}|{mouseY_R}");
                Thread.Sleep(50);
                Cursor.Position = new Point(mouseX_R, mouseY_R);
                Mouse.SendLeftClick();
                Thread.Sleep(lootTimer);
                BC.DarkBlue($"Moving mouse to {mouseX_Space}|{mouseY_Space}");
                Thread.Sleep(50);
                Cursor.Position = new Point(mouseX_Space, mouseY_Space);
                Mouse.SendLeftClick();
                WindowHelper.SwitchWindow(penguin);
                spinner.Stop();
            }                  
            
        }


        public static void Init()
        {
            if(!init)
            {
                HotKeyManager.RegisterHotKey(Keys.F1, KeyModifiers.Shift);
                HotKeyManager.RegisterHotKey(Keys.F2, KeyModifiers.Shift);
                HotKeyManager.RegisterHotKey(Keys.F3, KeyModifiers.Shift);
                HotKeyManager.HotKeyPressed += HotKeyFired;

                Process[] processes = Process.GetProcessesByName("BlackDesert64");

                if (processes.Length == 0)
                    throw new Exception("Could not find the BlackDesert process; is BlackDesert running?");
                bdoHandle = processes[0].MainWindowHandle;

                penguin = WindowHelper.GetWindowTitle();    

                init = true;
            }
            
        }

        private static void HotKeyFired(object sender, HotKeyEventArgs e)
        {
            if (e.Key == Keys.F1)
            {
                //User pressed f1!
                mouseX_Space = Cursor.Position.X;
                mouseY_Space = Cursor.Position.Y;
                BC.DarkGray($"Space X:{mouseX_Space} | Y:{mouseY_Space}");
            }
            if (e.Key == Keys.F2)
            {
                mouseX_R = Cursor.Position.X;
                mouseY_R = Cursor.Position.Y;
                BC.DarkGray($"Space X:{mouseX_R} | Y:{mouseY_R}");
            }
            if (e.Key == Keys.F3)
            {
                cont = false;
            }
        }
    }
}
