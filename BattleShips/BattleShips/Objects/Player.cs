using System.Collections.Generic;

namespace BattleShips
{
    internal class Player
    {
        internal Cell[,] board;

        internal List<Ship> playerTwoShips = new List<Ship>()
        {
            new Ship(2),
            new Ship(3),
            new Ship(3),
            new Ship(4),
            new Ship(5)
        };
    }
}
