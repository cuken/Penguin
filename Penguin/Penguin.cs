using System;
using BetterConsole;

namespace Penguin
{
    public class Penguin
    {
        static void Main(string[] args) => new Penguin().Start(args);

        private void Start(string[] args)
        {
            BetterConsole.CSC.BlankLines(50);
            BetterConsole.Colors.Red("Hello World!");

            int age = CSC.ValidateQuestion("How old are you? ", "PLEASE JUST GIVE ME A NUMBER!");
            Console.WriteLine($"In 10 years you will be: {age + 10}");
            Console.ReadLine();
        }
    }
}
