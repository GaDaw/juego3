using System;

namespace FightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = '\u263A'.ToString();
            System.Console.WriteLine('\u263B');

            var game = new Game();
            game.Start();
        }
    }
}
