using System;

namespace BattleShips
{
    internal class InputService
    {
        internal string GetPlayerInput()
        {
            return Console.ReadLine();
        }

        internal void CheckPlayerInput(string playerInput, Cell[,] boardHolder)
        {
            CheckBoardBoundaries();

            throw new NotImplementedException();
        }
    }
}