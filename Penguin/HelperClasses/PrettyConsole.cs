#region MITLicense

//The MIT License (MIT)

//Copyright(c) [2016]
//Colin Uken

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.

#endregion

using System;

namespace Penguin
{
    /// <summary>
    /// Class that streamlines changing colors in the console.
    /// </summary>
    public static class BC
    {
        /// <summary>
        /// Writes text to the console with the specified ConsoleColor. Returns to the previous color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="foreground">The ConsoleColor you want your text to be.</param>
        public static void Write(string text, ConsoleColor foreground)
        {
            var originalFGColor = Console.ForegroundColor;
            Console.ForegroundColor = foreground;
            Console.Write(text);
            Console.ForegroundColor = originalFGColor;
        }

        /// <summary>
        /// Writes a new line of text to the console with a specified ConsoleColor. Returns to the previous color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="foreground">The ConsoleColor you want your text to be.</param>
        public static void WriteLine(string text, ConsoleColor foreground)
        {
            var originalFGColor = Console.ForegroundColor;
            Console.ForegroundColor = foreground;
            Console.WriteLine(text);
            Console.ForegroundColor = originalFGColor;
        }

        /// <summary>
        /// Writes text to the console with the specified ConsoleColor. Changes the background to the specified ConsoleColor.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="foreground">The ConsoleColor you want your text to be.</param>
        /// <param name="background">The ConsoleColor you want your background to be.</param>
        public static void Write(string text, ConsoleColor foreground, ConsoleColor background)
        {
            var originalFGColor = Console.ForegroundColor;
            var originalBGColor = Console.BackgroundColor;
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
            Console.Write(text);
            Console.ForegroundColor = originalFGColor;
            Console.BackgroundColor = originalBGColor;
        }

        /// <summary>
        /// Writes a line of text to the console with the specified ConsoleColor. Changes the background to the specified ConsoleColor.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="foreground">The ConsoleColor you want your text to be.</param>
        /// <param name="background">The ConsoleColor you want your background to be.</param>
        public static void WriteLine(string text, ConsoleColor foreground, ConsoleColor background)
        {
            var originalFGColor = Console.ForegroundColor;
            var originalBGColor = Console.BackgroundColor;
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
            Console.WriteLine(text);
            Console.ForegroundColor = originalFGColor;
            Console.BackgroundColor = originalBGColor;
        }

        /// <summary>
        /// Writes text to the console with the specified ConsoleColor. Changes the background to the specified ConsoleColor. Set last param to false to keep the color change.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="foreground">The ConsoleColor you want your text to be.</param>
        /// <param name="background">The ConsoleColor you want your background to be.</param>
        /// <param name="revert">Boolean value that determines  whether or not to switch the colors back.</param>
        public static void Write(string text, ConsoleColor foreground, ConsoleColor background, bool revert)
        {
            var originalFGColor = Console.ForegroundColor;
            var originalBGColor = Console.BackgroundColor;
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
            Console.Write(text);
            if(revert)
            {
                Console.ForegroundColor = originalFGColor;
                Console.BackgroundColor = originalBGColor;
            }            
        }

        /// <summary>
        /// Writes a line of text to the console with the specified ConsoleColor. Changes the background to the specified ConsoleColor. Set last param to false to keep the color change.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="foreground">The ConsoleColor you want your text to be.</param>
        /// <param name="background">The ConsoleColor you want your background to be.</param>
        /// <param name="revert">Boolean value that determines  whether or not to switch the colors back.</param>
        public static void WriteLine(string text, ConsoleColor foreground, ConsoleColor background, bool revert)
        {
            var originalFGColor = Console.ForegroundColor;
            var originalBGColor = Console.BackgroundColor;
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
            Console.WriteLine(text);
            if(revert)
            {
                Console.ForegroundColor = originalFGColor;
                Console.BackgroundColor = originalBGColor;
            }            
        }

        /// <summary>
        /// Writes Black text to the console. Returns to the previous color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        public static void Black(string text)
        {
            Write(text, ConsoleColor.Black);
        }

        /// <summary>
        /// Writese a line of Black text to the console. Returns to the previous color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        public static void BlackLine(string text)
        {
            WriteLine(text, ConsoleColor.Black);
        }

        /// <summary>
        /// Writes Blue text to the console. Returns to the previous color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        public static void Blue(string text)
        {
            Write(text, ConsoleColor.Blue);
        }

        /// <summary>
        /// Writese a line of Blue text to the console. Returns to the previous color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        public static void BlueLine(string text)
        {
            WriteLine(text, ConsoleColor.Blue);
        }

        /// <summary>
        /// Writes Cyan text to the console. Returns to the previous color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        public static void Cyan(string text)
        {
            Write(text, ConsoleColor.Cyan);
        }

        /// <summary>
        /// Writese a line of Cyan text to the console. Returns to the previous color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        public static void CyanLine(string text)
        {
            WriteLine(text, ConsoleColor.Cyan);
        }

        /// <summary>
        /// Writes DarkBlue text to the console. Returns to the previous color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        public static void DarkBlue(string text)
        {
            Write(text, ConsoleColor.DarkBlue);
        }

        /// <summary>
        /// Writese a line of DarkBlue text to the console. Returns to the previous color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        public static void DarkBlueLine(string text)
        {
            WriteLine(text, ConsoleColor.DarkBlue);
        }

        /// <summary>
        /// Writes DarkCyan text to the console. Returns to the previous color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        public static void DarkCyan(string text)
        {
            Write(text, ConsoleColor.DarkCyan);
        }

        /// <summary>
        /// Writese a line of DarkCyan text to the console. Returns to the previous color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        public static void DarkCyanLine(string text)
        {
            WriteLine(text, ConsoleColor.DarkCyan);
        }

        /// <summary>
        /// Writes DarkGray text to the console. Returns to the previous color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        public static void DarkGray(string text)
        {
            Write(text, ConsoleColor.DarkGray);
        }

        /// <summary>
        /// Writese a line of DarkGray text to the console. Returns to the previous color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        public static void DarkGrayLine(string text)
        {
            WriteLine(text, ConsoleColor.DarkGray);
        }

        /// <summary>
        /// Writes DarkGreen text to the console. Returns to the previous color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        public static void DarkGreen(string text)
        {
            Write(text, ConsoleColor.DarkGreen);
        }

        /// <summary>
        /// Writese a line of DarkGreen text to the console. Returns to the previous color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        public static void DarkGreenLine(string text)
        {
            WriteLine(text, ConsoleColor.DarkGreen);
        }

        /// <summary>
        /// Writes Darkmagenta text to the console. Returns to the previous color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        public static void DarkMagenta(string text)
        {
            Write(text, ConsoleColor.DarkMagenta);
        }

        /// <summary>
        /// Writese a line of DarkMagenta text to the console. Returns to the previous color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        public static void DarkMagentaLine(string text)
        {
            WriteLine(text, ConsoleColor.DarkMagenta);
        }

        /// <summary>
        /// Writes DarkRed text to the console. Returns to the previous color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        public static void DarkRed(string text)
        {
            Write(text, ConsoleColor.DarkRed);
        }

        /// <summary>
        /// Writese a line of DarkRed text to the console. Returns to the previous color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        public static void DarkRedLine(string text)
        {
            WriteLine(text, ConsoleColor.DarkRed);
        }

        /// <summary>
        /// Writes DarkYellow text to the console. Returns to the previous color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        public static void DarkYellow(string text)
        {
            Write(text, ConsoleColor.DarkYellow);
        }

        /// <summary>
        /// Writese a line of DarkYellow text to the console. Returns to the previous color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        public static void DarkYellowLine(string text)
        {
            WriteLine(text, ConsoleColor.DarkYellow);
        }

        /// <summary>
        /// Writes Gray text to the console. Returns to the previous color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        public static void Gray(string text)
        {
            Write(text, ConsoleColor.Gray);
        }

        /// <summary>
        /// Writese a line of Gray text to the console. Returns to the previous color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        public static void GrayLine(string text)
        {
            WriteLine(text, ConsoleColor.DarkYellow);
        }

        /// <summary>
        /// Writes Green text to the console. Returns to the previous color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        public static void Green(string text)
        {
            Write(text, ConsoleColor.Green);
        }

        /// <summary>
        /// Writese a line of Green text to the console. Returns to the previous color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        public static void GreenLine(string text)
        {
            WriteLine(text, ConsoleColor.Green);
        }

        /// <summary>
        /// Writes Magenta text to the console. Returns to the previous color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        public static void Magenta(string text)
        {
            Write(text, ConsoleColor.Magenta);
        }

        /// <summary>
        /// Writese a line of Magenta text to the console. Returns to the previous color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        public static void MagentaLine(string text)
        {
            WriteLine(text, ConsoleColor.Magenta);
        }

        /// <summary>
        /// Writes Red text to the console. Returns to the previous color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        public static void Red(string text)
        {
            Write(text, ConsoleColor.Red);
        }

        /// <summary>
        /// Writese a line of Red text to the console. Returns to the previous color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        public static void RedLine(string text)
        {
            WriteLine(text, ConsoleColor.Red);
        }

        /// <summary>
        /// Writes White text to the console. Returns to the previous color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        public static void White(string text)
        {
            Write(text, ConsoleColor.White);
        }

        /// <summary>
        /// Writese a line of White text to the console. Returns to the previous color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        public static void WhiteLine(string text)
        {
            WriteLine(text, ConsoleColor.White);
        }

        /// <summary>
        /// Writes Blue text to the console. Returns to the previous color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        public static void Yellow(string text)
        {
            Write(text, ConsoleColor.Yellow);
        }

        /// <summary>
        /// Writese a line of Yellow text to the console. Returns to the previous color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        public static void YellowLine(string text)
        {
            WriteLine(text, ConsoleColor.Yellow);
        }

        /// <summary>
        /// Writes Black text to the console. Changes the background color of the console to the supplied ConsoleColor. Returns the text and background back to the original color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be.</param>
        public static void Black(string text, ConsoleColor background)
        {
            Write(text, ConsoleColor.Black, background);
        }

        /// <summary>
        /// Writes a line of Black text to the console. Changes the background color of the console to the supplied ConsoleColor. Returns the text and background to the original color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be.</param>
        public static void BlackLine(string text, ConsoleColor background)
        {
            WriteLine(text, ConsoleColor.Black, background);
        }

        /// <summary>
        /// Writes Blue text to the console. Changes the background color of the console to the supplied ConsoleColor. Returns the text and background back to the original color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be.</param>
        public static void Blue(string text, ConsoleColor background)
        {
            Write(text, ConsoleColor.Blue, background);
        }

        /// <summary>
        /// Writes a line of Blue text to the console. Changes the background color of the console to the supplied ConsoleColor. Returns the text and background to the original color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be.</param>
        public static void BlueLine(string text, ConsoleColor background)
        {
            WriteLine(text, ConsoleColor.Blue, background);
        }

        /// <summary>
        /// Writes Cyan text to the console. Changes the background color of the console to the supplied ConsoleColor. Returns the text and background back to the original color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be.</param>
        public static void Cyan(string text, ConsoleColor background)
        {
            Write(text, ConsoleColor.Cyan, background);
        }

        /// <summary>
        /// Writes a line of Cyan text to the console. Changes the background color of the console to the supplied ConsoleColor. Returns the text and background to the original color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be.</param>
        public static void CyanLine(string text, ConsoleColor background)
        {
            WriteLine(text, ConsoleColor.Cyan, background);
        }

        /// <summary>
        /// Writes DarkBlue text to the console. Changes the background color of the console to the supplied ConsoleColor. Returns the text and background back to the original color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be.</param>
        public static void DarkBlue(string text, ConsoleColor background)
        {
            Write(text, ConsoleColor.DarkBlue, background);
        }

        /// <summary>
        /// Writes a line of DarkBlue text to the console. Changes the background color of the console to the supplied ConsoleColor. Returns the text and background to the original color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be.</param>
        public static void DarkBlueLine(string text, ConsoleColor background)
        {
            WriteLine(text, ConsoleColor.DarkBlue, background);
        }

        /// <summary>
        /// Writes DarkCyan text to the console. Changes the background color of the console to the supplied ConsoleColor. Returns the text and background back to the original color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be.</param>
        public static void DarkCyan(string text, ConsoleColor background)
        {
            Write(text, ConsoleColor.DarkCyan, background);
        }

        /// <summary>
        /// Writes a line of DarkCyan text to the console. Changes the background color of the console to the supplied ConsoleColor. Returns the text and background to the original color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be.</param>
        public static void DarkCyanLine(string text, ConsoleColor background)
        {
            WriteLine(text, ConsoleColor.DarkCyan, background);
        }

        /// <summary>
        /// Writes DarkGray text to the console. Changes the background color of the console to the supplied ConsoleColor. Returns the text and background back to the original color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be.</param>
        public static void DarkGray(string text, ConsoleColor background)
        {
            Write(text, ConsoleColor.DarkGray, background);
        }

        /// <summary>
        /// Writes a line of DarkGray text to the console. Changes the background color of the console to the supplied ConsoleColor. Returns the text and background to the original color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be.</param>
        public static void DarkGrayLine(string text, ConsoleColor background)
        {
            WriteLine(text, ConsoleColor.DarkGray, background);
        }

        /// <summary>
        /// Writes DarkGreen text to the console. Changes the background color of the console to the supplied ConsoleColor. Returns the text and background back to the original color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be.</param>
        public static void DarkGreen(string text, ConsoleColor background)
        {
            Write(text, ConsoleColor.DarkGreen, background);
        }

        /// <summary>
        /// Writes a line of DarkGreen text to the console. Changes the background color of the console to the supplied ConsoleColor. Returns the text and background to the original color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be.</param>
        public static void DarkGreenLine(string text, ConsoleColor background)
        {
            WriteLine(text, ConsoleColor.DarkGreen, background);
        }

        /// <summary>
        /// Writes DarkMagenta text to the console. Changes the background color of the console to the supplied ConsoleColor. Returns the text and background back to the original color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be.</param>
        public static void DarkMagenta(string text, ConsoleColor background)
        {
            Write(text, ConsoleColor.DarkMagenta, background);
        }

        /// <summary>
        /// Writes a line of DarkMagenta text to the console. Changes the background color of the console to the supplied ConsoleColor. Returns the text and background to the original color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be.</param>
        public static void DarkMagentaLine(string text, ConsoleColor background)
        {
            WriteLine(text, ConsoleColor.DarkMagenta, background);
        }

        /// <summary>
        /// Writes DarkRed text to the console. Changes the background color of the console to the supplied ConsoleColor. Returns the text and background back to the original color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be.</param>
        public static void DarkRed(string text, ConsoleColor background)
        {
            Write(text, ConsoleColor.DarkRed, background);
        }

        /// <summary>
        /// Writes a line of DarkRed text to the console. Changes the background color of the console to the supplied ConsoleColor. Returns the text and background to the original color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be.</param>
        public static void DarkRedLine(string text, ConsoleColor background)
        {
            WriteLine(text, ConsoleColor.DarkRed, background);
        }

        /// <summary>
        /// Writes DarkYellow text to the console. Changes the background color of the console to the supplied ConsoleColor. Returns the text and background back to the original color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be.</param>
        public static void DarkYellow(string text, ConsoleColor background)
        {
            Write(text, ConsoleColor.DarkYellow, background);
        }

        /// <summary>
        /// Writes a line of DarkkYellow text to the console. Changes the background color of the console to the supplied ConsoleColor. Returns the text and background to the original color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be.</param>
        public static void DarkYellowLine(string text, ConsoleColor background)
        {
            WriteLine(text, ConsoleColor.DarkYellow, background);
        }

        /// <summary>
        /// Writes Gray text to the console. Changes the background color of the console to the supplied ConsoleColor. Returns the text and background back to the original color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be.</param>
        public static void Gray(string text, ConsoleColor background)
        {
            Write(text, ConsoleColor.Gray, background);
        }

        /// <summary>
        /// Writes a line of GrayLine text to the console. Changes the background color of the console to the supplied ConsoleColor. Returns the text and background to the original color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be.</param>
        public static void GrayLine(string text, ConsoleColor background)
        {
            WriteLine(text, ConsoleColor.Gray, background);
        }

        /// <summary>
        /// Writes Green text to the console. Changes the background color of the console to the supplied ConsoleColor. Returns the text and background back to the original color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be.</param>
        public static void Green(string text, ConsoleColor background)
        {
            Write(text, ConsoleColor.Green, background);
        }

        /// <summary>
        /// Writes a line of GreenLine text to the console. Changes the background color of the console to the supplied ConsoleColor. Returns the text and background to the original color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be.</param>
        public static void GreenLine(string text, ConsoleColor background)
        {
            WriteLine(text, ConsoleColor.Green, background);
        }

        /// <summary>
        /// Writes Magenta text to the console. Changes the background color of the console to the supplied ConsoleColor. Returns the text and background back to the original color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be.</param>
        public static void Magenta(string text, ConsoleColor background)
        {
            Write(text, ConsoleColor.Magenta, background);
        }

        /// <summary>
        /// Writes a line of Megenta text to the console. Changes the background color of the console to the supplied ConsoleColor. Returns the text and background to the original color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be.</param>
        public static void MagentaLine(string text, ConsoleColor background)
        {
            WriteLine(text, ConsoleColor.Magenta, background);
        }

        /// <summary>
        /// Writes Red text to the console. Changes the background color of the console to the supplied ConsoleColor. Returns the text and background back to the original color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be.</param>
        public static void Red(string text, ConsoleColor background)
        {
            Write(text, ConsoleColor.Red, background);
        }

        /// <summary>
        /// Writes a line of Red text to the console. Changes the background color of the console to the supplied ConsoleColor. Returns the text and background to the original color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be.</param>
        public static void RedLine(string text, ConsoleColor background)
        {
            WriteLine(text, ConsoleColor.Red, background);
        }

        /// <summary>
        /// Writes White text to the console. Changes the background color of the console to the supplied ConsoleColor. Returns the text and background back to the original color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be.</param>
        public static void White(string text, ConsoleColor background)
        {
            Write(text, ConsoleColor.White, background);
        }

        /// <summary>
        /// Writes a line of White text to the console. Changes the background color of the console to the supplied ConsoleColor. Returns the text and background to the original color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be.</param>
        public static void WhiteLine(string text, ConsoleColor background)
        {
            WriteLine(text, ConsoleColor.White, background);
        }

        /// <summary>
        /// Writes Yellow text to the console. Changes the background color of the console to the supplied ConsoleColor. Returns the text and background back to the original color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be.</param>
        public static void Yellow(string text, ConsoleColor background)
        {
            Write(text, ConsoleColor.Yellow, background);
        }

        /// <summary>
        /// Writes a line of Yellow text to the console. Changes the background color of the console to the supplied ConsoleColor. Returns the text and background to the original color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be.</param>
        public static void YellowLine(string text, ConsoleColor background)
        {
            WriteLine(text, ConsoleColor.Yellow, background);
        }

        /// <summary>
        /// Writes Black text to the console. Changes the background color of the console to the supplied ConsoleColor. Uses a boolean value to determine whether or not to revert color changes when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be</param>
        /// <param name="revert">Boolean value that determines whether or not to switch the colors back.</param>
        public static void Black(string text, ConsoleColor background, bool revert)
        {
            Write(text, ConsoleColor.Black, background, revert);
        }

        /// <summary>
        /// Writes a line of Black text to the console. Changes the background color of the console to the supplied ConsoleColor. Uses a boolean value to determine whether or not to revert color changes when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be</param>
        /// <param name="revert">Boolean value that determines whether or not to switch the colors back.</param>
        public static void BlackLine(string text, ConsoleColor background, bool revert)
        {
            WriteLine(text, ConsoleColor.Black, background, revert);
        }

        /// <summary>
        /// Writes Blue text to the console. Changes the background color of the console to the supplied ConsoleColor. Uses a boolean value to determine whether or not to revert color changes when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be</param>
        /// <param name="revert">Boolean value that determines whether or not to switch the colors back.</param>
        public static void Blue(string text, ConsoleColor background, bool revert)
        {
            Write(text, ConsoleColor.Blue, background, revert);
        }

        /// <summary>
        /// Writes a line of Blue text to the console. Changes the background color of the console to the supplied ConsoleColor. Uses a boolean value to determine whether or not to revert color changes when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be</param>
        /// <param name="revert">Boolean value that determines whether or not to switch the colors back.</param>
        public static void BlueLine(string text, ConsoleColor background, bool revert)
        {
            WriteLine(text, ConsoleColor.Blue, background, revert);
        }

        /// <summary>
        /// Writes Cyan text to the console. Changes the background color of the console to the supplied ConsoleColor. Uses a boolean value to determine whether or not to revert color changes when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be</param>
        /// <param name="revert">Boolean value that determines whether or not to switch the colors back.</param>
        public static void Cyan(string text, ConsoleColor background, bool revert)
        {
            Write(text, ConsoleColor.Cyan, background, revert);
        }

        /// <summary>
        /// Writes a line of Cyan text to the console. Changes the background color of the console to the supplied ConsoleColor. Uses a boolean value to determine whether or not to revert color changes when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be</param>
        /// <param name="revert">Boolean value that determines whether or not to switch the colors back.</param>
        public static void CyanLine(string text, ConsoleColor background, bool revert)
        {
            WriteLine(text, ConsoleColor.Cyan, background, revert);
        }

        /// <summary>
        /// Writes DarkBlue text to the console. Changes the background color of the console to the supplied ConsoleColor. Uses a boolean value to determine whether or not to revert color changes when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be</param>
        /// <param name="revert">Boolean value that determines whether or not to switch the colors back.</param>
        public static void DarkBlue(string text, ConsoleColor background, bool revert)
        {
            Write(text, ConsoleColor.DarkBlue, background, revert);
        }

        /// <summary>
        /// Writes a line of DarkBlue text to the console. Changes the background color of the console to the supplied ConsoleColor. Uses a boolean value to determine whether or not to revert color changes when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be</param>
        /// <param name="revert">Boolean value that determines whether or not to switch the colors back.</param>
        public static void DarkBlueLine(string text, ConsoleColor background, bool revert)
        {
            WriteLine(text, ConsoleColor.DarkBlue, background, revert);
        }

        /// <summary>
        /// Writes DarkCyan text to the console. Changes the background color of the console to the supplied ConsoleColor. Uses a boolean value to determine whether or not to revert color changes when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be</param>
        /// <param name="revert">Boolean value that determines whether or not to switch the colors back.</param>
        public static void DarkCyan(string text, ConsoleColor background, bool revert)
        {
            Write(text, ConsoleColor.DarkCyan, background, revert);
        }

        /// <summary>
        /// Writes a line of DarkCyan text to the console. Changes the background color of the console to the supplied ConsoleColor. Uses a boolean value to determine whether or not to revert color changes when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be</param>
        /// <param name="revert">Boolean value that determines whether or not to switch the colors back.</param>
        public static void DarkCyanLine(string text, ConsoleColor background, bool revert)
        {
            WriteLine(text, ConsoleColor.DarkCyan, background, revert);
        }

        /// <summary>
        /// Writes DarkGray text to the console. Changes the background color of the console to the supplied ConsoleColor. Uses a boolean value to determine whether or not to revert color changes when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be</param>
        /// <param name="revert">Boolean value that determines whether or not to switch the colors back.</param>
        public static void DarkGray(string text, ConsoleColor background, bool revert)
        {
            Write(text, ConsoleColor.DarkGray, background, revert);
        }

        /// <summary>
        /// Writes a line of DarkGray text to the console. Changes the background color of the console to the supplied ConsoleColor. Uses a boolean value to determine whether or not to revert color changes when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be</param>
        /// <param name="revert">Boolean value that determines whether or not to switch the colors back.</param>
        public static void DarkGrayLine(string text, ConsoleColor background, bool revert)
        {
            WriteLine(text, ConsoleColor.DarkGray, background, revert);
        }

        /// <summary>
        /// Writes DarkGreen text to the console. Changes the background color of the console to the supplied ConsoleColor. Uses a boolean value to determine whether or not to revert color changes when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be</param>
        /// <param name="revert">Boolean value that determines whether or not to switch the colors back.</param>
        public static void DarkGreen(string text, ConsoleColor background, bool revert)
        {
            Write(text, ConsoleColor.DarkGreen, background, revert);
        }

        /// <summary>
        /// Writes a line of DarkGreen text to the console. Changes the background color of the console to the supplied ConsoleColor. Uses a boolean value to determine whether or not to revert color changes when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be</param>
        /// <param name="revert">Boolean value that determines whether or not to switch the colors back.</param>
        public static void DarkGreenLine(string text, ConsoleColor background, bool revert)
        {
            WriteLine(text, ConsoleColor.DarkGreen, background, revert);
        }

        /// <summary>
        /// Writes DarkMagenta text to the console. Changes the background color of the console to the supplied ConsoleColor. Uses a boolean value to determine whether or not to revert color changes when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be</param>
        /// <param name="revert">Boolean value that determines whether or not to switch the colors back.</param>
        public static void DarkMagenta(string text, ConsoleColor background, bool revert)
        {
            Write(text, ConsoleColor.DarkMagenta, background, revert);
        }

        /// <summary>
        /// Writes a line of DarkMagenta text to the console. Changes the background color of the console to the supplied ConsoleColor. Uses a boolean value to determine whether or not to revert color changes when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be</param>
        /// <param name="revert">Boolean value that determines whether or not to switch the colors back.</param>
        public static void DarkMagentaLine(string text, ConsoleColor background, bool revert)
        {
            WriteLine(text, ConsoleColor.DarkMagenta, background, revert);
        }

        /// <summary>
        /// Writes DarkRed text to the console. Changes the background color of the console to the supplied ConsoleColor. Uses a boolean value to determine whether or not to revert color changes when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be</param>
        /// <param name="revert">Boolean value that determines whether or not to switch the colors back.</param>
        public static void DarkRed(string text, ConsoleColor background, bool revert)
        {
            Write(text, ConsoleColor.DarkRed, background, revert);
        }

        /// <summary>
        /// Writes a line of DarkRed text to the console. Changes the background color of the console to the supplied ConsoleColor. Uses a boolean value to determine whether or not to revert color changes when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be</param>
        /// <param name="revert">Boolean value that determines whether or not to switch the colors back.</param>
        public static void DarkRedLine(string text, ConsoleColor background, bool revert)
        {
            WriteLine(text, ConsoleColor.DarkRed, background, revert);
        }

        /// <summary>
        /// Writes DarkYellow text to the console. Changes the background color of the console to the supplied ConsoleColor. Uses a boolean value to determine whether or not to revert color changes when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be</param>
        /// <param name="revert">Boolean value that determines whether or not to switch the colors back.</param>
        public static void DarkYellow(string text, ConsoleColor background, bool revert)
        {
            Write(text, ConsoleColor.DarkYellow, background, revert);
        }

        /// <summary>
        /// Writes a line of DarkYellow text to the console. Changes the background color of the console to the supplied ConsoleColor. Uses a boolean value to determine whether or not to revert color changes when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be</param>
        /// <param name="revert">Boolean value that determines whether or not to switch the colors back.</param>
        public static void DarkYellowLine(string text, ConsoleColor background, bool revert)
        {
            WriteLine(text, ConsoleColor.DarkYellow, background, revert);
        }

        /// <summary>
        /// Writes Gray text to the console. Changes the background color of the console to the supplied ConsoleColor. Uses a boolean value to determine whether or not to revert color changes when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be</param>
        /// <param name="revert">Boolean value that determines whether or not to switch the colors back.</param>
        public static void Gray(string text, ConsoleColor background, bool revert)
        {
            Write(text, ConsoleColor.Gray, background, revert);
        }

        /// <summary>
        /// Writes a line of Gray text to the console. Changes the background color of the console to the supplied ConsoleColor. Uses a boolean value to determine whether or not to revert color changes when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be</param>
        /// <param name="revert">Boolean value that determines whether or not to switch the colors back.</param>
        public static void GrayLine(string text, ConsoleColor background, bool revert)
        {
            WriteLine(text, ConsoleColor.Gray, background, revert);
        }

        /// <summary>
        /// Writes Green text to the console. Changes the background color of the console to the supplied ConsoleColor. Uses a boolean value to determine whether or not to revert color changes when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be</param>
        /// <param name="revert">Boolean value that determines whether or not to switch the colors back.</param>
        public static void Green(string text, ConsoleColor background, bool revert)
        {
            Write(text, ConsoleColor.Green, background, revert);
        }

        /// <summary>
        /// Writes a line of Green text to the console. Changes the background color of the console to the supplied ConsoleColor. Uses a boolean value to determine whether or not to revert color changes when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be</param>
        /// <param name="revert">Boolean value that determines whether or not to switch the colors back.</param>
        public static void GreenLine(string text, ConsoleColor background, bool revert)
        {
            WriteLine(text, ConsoleColor.Green, background, revert);
        }

        /// <summary>
        /// Writes Magenta text to the console. Changes the background color of the console to the supplied ConsoleColor. Uses a boolean value to determine whether or not to revert color changes when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be</param>
        /// <param name="revert">Boolean value that determines whether or not to switch the colors back.</param>
        public static void Magenta(string text, ConsoleColor background, bool revert)
        {
            Write(text, ConsoleColor.Magenta, background, revert);
        }

        /// <summary>
        /// Writes a line of Magenta text to the console. Changes the background color of the console to the supplied ConsoleColor. Uses a boolean value to determine whether or not to revert color changes when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be</param>
        /// <param name="revert">Boolean value that determines whether or not to switch the colors back.</param>
        public static void MagentaLine(string text, ConsoleColor background, bool revert)
        {
            WriteLine(text, ConsoleColor.Magenta, background, revert);
        }

        /// <summary>
        /// Writes Red text to the console. Changes the background color of the console to the supplied ConsoleColor. Uses a boolean value to determine whether or not to revert color changes when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be</param>
        /// <param name="revert">Boolean value that determines whether or not to switch the colors back.</param>
        public static void Red(string text, ConsoleColor background, bool revert)
        {
            Write(text, ConsoleColor.Red, background, revert);
        }

        /// <summary>
        /// Writes a line of Red text to the console. Changes the background color of the console to the supplied ConsoleColor. Uses a boolean value to determine whether or not to revert color changes when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be</param>
        /// <param name="revert">Boolean value that determines whether or not to switch the colors back.</param>
        public static void RedLine(string text, ConsoleColor background, bool revert)
        {
            WriteLine(text, ConsoleColor.Red, background, revert);
        }

        /// <summary>
        /// Writes White text to the console. Changes the background color of the console to the supplied ConsoleColor. Uses a boolean value to determine whether or not to revert color changes when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be</param>
        /// <param name="revert">Boolean value that determines whether or not to switch the colors back.</param>
        public static void White(string text, ConsoleColor background, bool revert)
        {
            Write(text, ConsoleColor.White, background, revert);
        }

        /// <summary>
        /// Writes a line of White text to the console. Changes the background color of the console to the supplied ConsoleColor. Uses a boolean value to determine whether or not to revert color changes when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be</param>
        /// <param name="revert">Boolean value that determines whether or not to switch the colors back.</param>
        public static void WhiteLine(string text, ConsoleColor background, bool revert)
        {
            WriteLine(text, ConsoleColor.White, background, revert);
        }

        /// <summary>
        /// Writes Yellow text to the console. Changes the background color of the console to the supplied ConsoleColor. Uses a boolean value to determine whether or not to revert color changes when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be</param>
        /// <param name="revert">Boolean value that determines whether or not to switch the colors back.</param>
        public static void Yellow(string text, ConsoleColor background, bool revert)
        {
            Write(text, ConsoleColor.Yellow, background, revert);
        }

        /// <summary>
        /// Writes a line of Yellow text to the console. Changes the background color of the console to the supplied ConsoleColor. Uses a boolean value to determine whether or not to revert color changes when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be</param>
        /// <param name="revert">Boolean value that determines whether or not to switch the colors back.</param>
        public static void YellowLine(string text, ConsoleColor background, bool revert)
        {
            WriteLine(text, ConsoleColor.Yellow, background, revert);
        }

        //!International Variants

        /// <summary>
        /// Writes Grey text to the console. Returns to the previous color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        public static void Grey(string text)
        {
            Write(text, ConsoleColor.Gray);
        }

        /// <summary>
        /// Writese a line of Gray text to the console. Returns to the previous color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        public static void GraeLine(string text)
        {
            WriteLine(text, ConsoleColor.DarkYellow);
        }

        /// <summary>
        /// Writes Grey text to the console. Changes the background color of the console to the supplied ConsoleColor. Returns the text and background back to the original color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be.</param>
        public static void Grey(string text, ConsoleColor background)
        {
            Write(text, ConsoleColor.Gray, background);
        }

        /// <summary>
        /// Writes a line of GreyLine text to the console. Changes the background color of the console to the supplied ConsoleColor. Returns the text and background to the original color when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be.</param>
        public static void GreyLine(string text, ConsoleColor background)
        {
            WriteLine(text, ConsoleColor.Gray, background);
        }

        /// <summary>
        /// Writes Grey text to the console. Changes the background color of the console to the supplied ConsoleColor. Uses a boolean value to determine whether or not to revert color changes when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be</param>
        /// <param name="revert">Boolean value that determines whether or not to switch the colors back.</param>
        public static void Grey(string text, ConsoleColor background, bool revert)
        {
            Write(text, ConsoleColor.Gray, background, revert);
        }

        /// <summary>
        /// Writes a line of Grey text to the console. Changes the background color of the console to the supplied ConsoleColor. Uses a boolean value to determine whether or not to revert color changes when complete.
        /// </summary>
        /// <param name="text">The string you want to type.</param>
        /// <param name="background">The ConsoleColor you want the background to be</param>
        /// <param name="revert">Boolean value that determines whether or not to switch the colors back.</param>
        public static void GreyLine(string text, ConsoleColor background, bool revert)
        {
            WriteLine(text, ConsoleColor.Gray, background, revert);
        }

    }

    /// <summary>
    /// A Class with shortcuts for tedious Console.Write and Console.WriteLine commands
    /// </summary>
    public static class SC
    {
        /// <summary>
        /// Creates X number of blank lines.
        /// </summary>
        /// <param name="numReturns">Number of blank lines you want to create.</param>
        public static void BlankLines(int numReturns)
        {
            for (int i = 0; i < numReturns; i++)
            {
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Writes the text to the center of the console. Will automatically wrap the text if it exceeds the console bounds.
        /// </summary>
        /// <param name="text">The text you want written.</param>
        public static void WriteCenter(string text)
        {
            int length = text.Length;     
            while(text.Length > Console.WindowWidth)
            {
                length -= Console.WindowWidth;
                Console.Write(text.Substring(0, Console.WindowWidth));
                text = text.Substring(Console.WindowWidth, length);
            }

            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));

        }
        
        /// <summary>
        /// Writes the text right justified to the console. Will automatically wrap the text if it exceeds the console bounds.
        /// </summary>
        /// <param name="text">The text you want written.</param>
        public static void WriteRight(string text)
        {
            int length = text.Length;
            while (text.Length > Console.WindowWidth)
            {
                length -= Console.WindowWidth;
                Console.Write(text.Substring(0, Console.WindowWidth));
                text = text.Substring(Console.WindowWidth, length);
            }

            Console.SetCursorPosition(Console.WindowWidth-length, Console.CursorTop);
            Console.WriteLine(text);
        }


        /// <summary>
        /// Asks the user a question and waits for a response. Returns the response.
        /// </summary>
        /// <param name="question">The question you want displayed to the user.</param>
        /// <returns>Returns the response to the question</returns>
        public static string Question(string question)
        {
            string response;
            Console.Write(question + " ");
            response = Console.ReadLine();
            return response;
        }

        /// <summary>
        /// Asks the user a question and waits for the prompt. Validates ther esponse is a valid int, if not will reprompt the question.
        /// </summary>
        /// <param name="question">The question you want displayed to the user.</param>
        /// <returns>Returns an int value</returns>
        public static int ValidateQuestion(string question)
        {
            bool invalid = true;
            int result = 0;
            while (invalid)
            {
                string response = Question(question);

                if (int.TryParse(response, out result))
                {
                    invalid = false;
                }
                else
                {
                    Console.WriteLine("Invalid answer! Please provide a valid number to the question!");
                }
            }
            return result;            
        }

        /// <summary>
        /// Asks the user a question and waits for the prompt. Validates ther esponse is a valid int, if not, displays the supplied error and reprompts the question.
        /// </summary>
        /// <param name="question">The question you want displayed to the user.</param>
        /// <param name="error">The error message supplied when an invalid entry is found</param>
        /// <returns>Returns an int value</returns>
        public static int ValidateQuestion(string question, string error)
        {
            bool invalid = true;
            int result = 0;
            while (invalid)
            {
                string response = Question(question);

                if (int.TryParse(response, out result))
                {
                    invalid = false;
                }
                else
                {
                    Console.WriteLine(error);
                }
            }
            return result;
        }
    }
}
