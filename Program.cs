global using static System.Console;
using Microsoft.VisualBasic;
using System.Text;

namespace RPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OutputEncoding = Encoding.UTF8;
            CursorVisible = false;
            SetBufferSize(WindowWidth, WindowHeight);
            WriteLine("Please fullscreen the console and press any key to start.");
            ReadKey();
            StartNewGame();
        }

        public static void StartNewGame()
        {
            Game consolevania = new Game();
            consolevania.NameHero("");
        }
    }
}