using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Interceptor;

namespace Penguin.Classes
{
    class AutoFish
    {
        bool running = true;
        Input input = new Input();
        

        public void Start()
        {
            //Load Interceptor drivers
            input.KeyboardFilterMode = KeyboardFilterMode.All;
            input.Load();
            Console.Clear();
            Penguin.Banner();
            SC.BlankLines(2);
            BC.GreenLine("Penguin will \"perfect\" catch and recast automatically for you. There are configurable options for what quality of fish to loot coming later.");
            BC.RedLine("Plress any key to start");
            Console.ReadKey();
            Run();
        }

        private void Run()
        {
            throw new NotImplementedException();
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
            input.SendText("MM, I love you so much and I can't wait to have fun with you in Las Vegas. Love HB and his PENGUIN!");
            Thread.Sleep(500);
            input.SendKey(Keys.Enter);
            //input.SendKeys(Keys.Space);

            input.Unload();

        }
    }
}
