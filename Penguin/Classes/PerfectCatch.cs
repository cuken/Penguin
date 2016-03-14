using System;
using Penguin;
using System.Windows.Forms;
using System.Threading;
using Shortcut;

namespace Penguin.Classes
{
    public class PerfectCatch
    {
        //TIMERS ADJUST AS NEEDED
        int catchTimer = 2500;
        int switchTimer = 3000;
        int fishCaughtTimer = 3000;
        int lootTimer = 2000;
        //</TIMERS>

        string conWindow;
        string BDO;
        bool running = true;
        Spinner spinner = new Spinner("dash", Console.CursorLeft, Console.CursorTop, 100);

        public void Start()
        {
            Init();
            BC.YellowLine("When you are ready, please press any key to start a 10 second timer. Please refocus BDO and wait until the timer expires.");
            Console.ReadLine();
            spinner.Start();
            Thread.Sleep(10000);
            BDO = WindowHelper.GetWindowTitle();
            spinner.Stop();
            WindowHelper.SwitchWindow(conWindow);
            BC.GreenLine("Penguin is now ready to catch your fish! Press space in this window whenever the game tells you to hit space. Penguin will refocus, and catch your fish, then return focus to penguin. Press 'x' at any time to stop");
            ConsoleKey input = ConsoleKey.Spacebar;

            while (input != ConsoleKey.X)
            {
                Console.Clear();
                BC.CyanLine(Penguin.Banner());
                SC.BlankLines(4);
                Console.ForegroundColor = ConsoleColor.Green;
                SC.WriteCenter("Perfect Catch Mode!");
                Console.ForegroundColor = ConsoleColor.White;
                SC.BlankLines(2);
                SC.WriteCenter("Press 'Space' when BDO shows a fish is hooked.");
                SC.WriteCenter("Press 'X' to quit");
                spinner.Start();
                SC.BlankLines(3);
                input = Console.ReadKey().Key;

                if (input == ConsoleKey.Spacebar)
                {
                    spinner.Stop();
                    WindowHelper.SwitchWindow(BDO);

                    Thread.Sleep(switchTimer);

                    SendKeys.SendWait(" ");

                    Thread.Sleep(catchTimer);

                    SendKeys.SendWait(" ");

                    Thread.Sleep(fishCaughtTimer);

                    SendKeys.SendWait("r");

                    Thread.Sleep(lootTimer);

                    SendKeys.SendWait(" ");

                    WindowHelper.SwitchWindow(conWindow);                    
                }

            }

        }

        private void Init()
        {
            conWindow = WindowHelper.GetWindowTitle();
        }
    }
}

    //public class PerfectCatch
    //{

    //    static private IKeyboardEvents m_GlobalHook;

    //    static bool init = false;        
    //    static bool perfect = true;
    //    static bool running = false;
    //    static bool catching = false;
    //    static bool active = false;
    //    static Spinner spinner;
    //    static Spinner catchSpinner;
    //    static ManualResetEvent mre = new ManualResetEvent(false);

    //    static int perfectTimeToWait = 5000; //Time in MS to wait before hitting space.

    //    public static void Init()
    //    {
    //        if(!init)
    //        {
    //            m_GlobalHook = Hook.GlobalEvents();                
    //            //HotKeyManager.RegisterHotKey(Keys.F1, KeyModifiers.Alt);
    //            //HotKeyManager.RegisterHotKey(Keys.F2, KeyModifiers.Alt);
    //            //HotKeyManager.RegisterHotKey(Keys.F3, KeyModifiers.Alt);
    //            //HotKeyManager.RegisterHotKey(Keys.Space, KeyModifiers.NoRepeat);
    //            //HotKeyManager.HotKeyPressed += Perfect;
    //            //spinner = new Spinner("dash", Console.CursorLeft, Console.CursorTop, 100);
    //            //catchSpinner = new Spinner("dots", Console.CursorLeft, Console.CursorTop, 100);
    //            //Thread t = new Thread(PerfectRun);
    //            //t.Start();
    //            init = true;
    //        }
            
    //    }

    //    private static void GlobalHookKeyPress(object sender, KeyPressEventArgs e)
    //    {
    //        Console.WriteLine("KeyPress: \t{0}", e.KeyChar);
    //    }

    //    public static void Start()
    //    {
    //        Init();
    //        m_GlobalHook.KeyPress += GlobalHookKeyPress;
    //        active = true;
    //        Console.Clear();
    //        BC.CyanLine(Penguin.Banner());
    //        SC.BlankLines(2);
    //        BC.Magenta("[Alt + F1]");
    //        BC.WhiteLine(" Turns on PerfectCatch");
    //        BC.Magenta("[Alt + F2]");
    //        BC.WhiteLine(" Turns off PerfectCatch");
    //        BC.Magenta("[Alt + F3]");
    //        BC.WhiteLine(" Returns to Menu");

    //        while (perfect)
    //        {
    //            Thread.Sleep(100);
    //        }

    //        m_GlobalHook.KeyPress -= GlobalHookKeyPress;
    //    }

    //    private static void PerfectRun()
    //    {
            
    //        while (running)
    //        {                
    //            Thread.Sleep(100);
    //        }

    //    }

    //    private static void Catch()
    //    {
    //        catchSpinner.Start();
    //        //Stop Hotkey from firing;
    //        catching = true;

    //        //Wait for bar to fill.
    //        Thread.Sleep(perfectTimeToWait);

    //        //CATCH IT!
    //        BC.GreenLine("CATCH!");
    //        SendKeys.SendWait(" ");

    //        //Reregister Space.
    //        catching = false;
    //    }

    //    private static void Perfect(object sender, HotKeyEventArgs e)
    //    {
    //        if(active)
    //        {
    //            if (e.Key == Keys.F1)
    //            {
    //                if(!running)
    //                {
    //                    spinner.Start();
    //                    BC.DarkGrayLine("[F1] Command pressed!");
    //                    running = true;
    //                }                    
    //            }
    //            if (e.Key == Keys.F2)
    //            {
    //                if(running)
    //                {
    //                    spinner.Stop();
    //                    BC.DarkGrayLine("[F2] Command pressed!");
    //                    running = false;
    //                }                    
    //            }
    //            if (e.Key == Keys.F3)
    //            {
    //                spinner.Stop();
    //                BC.DarkGrayLine("[F3] Command pressed!");
    //                running = false;
    //                perfect = false;
    //                active = false;
    //            }
    //            if (e.Key == Keys.Space)
    //            {
    //                if (!catching && running) 
    //                {
    //                    spinner.Stop();
    //                    mre.Set();
    //                    BC.DarkGrayLine("SPACE HIT!");
    //                    Catch();
    //                    mre.WaitOne();
    //                    catchSpinner.Stop();
    //                    spinner.Start();
    //                }
    //            }
    //        }            
    //    }
    //}
