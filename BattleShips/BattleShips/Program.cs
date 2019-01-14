using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BattleShipsTests")]

namespace BattleShips
{
    class Program
    {
        static void Main(string[] args)
        {
            GameEngine start = new GameEngine();
            start.Game();

            Console.WriteLine("Finished!");
            Console.ReadKey();
        }
    }
}
