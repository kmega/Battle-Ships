using System.Collections.Generic;

namespace BattleShips
{
    internal class Ship
    {
        int length = 0;

        List<int[]> coordinates = new List<int[]>();

        public Ship(int shipLength)
        {
            length = shipLength;
        }
    }
}
