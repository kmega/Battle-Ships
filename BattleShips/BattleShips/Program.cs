using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips
{
    class Program
    {
        static void Main(string[] args)
        {
            GameEngine start = new GameEngine();
            start.Game();

            Console.ReadKey();
        }
    }
}
