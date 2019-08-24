using System.Collections.Generic;

namespace BattleShips
{
    internal class Ship
    {
        internal int length;

        internal List<int[]> coordinates = new List<int[]>();

        public Ship(int shipLength)
        {
            length = shipLength;
        }
    }
}
