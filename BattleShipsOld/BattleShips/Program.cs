using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BattleShipsTests")]

namespace BattleShips
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            GameEngine.StartBattleShips();
        }
    }
}
