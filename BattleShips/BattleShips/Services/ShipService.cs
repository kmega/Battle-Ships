using System;

namespace BattleShips
{
    internal class ShipService
    {
        internal void PlaceShips(ref Cell[,] playerOneBoard, ref Cell[,] playerTwoBoard)
        {
            // Create UserInterface() and show players boards for ship placement.
            UserInterface userInterface = new UserInterface();

            userInterface.ShowBoard(playerOneBoard);

            throw new NotImplementedException();
        }
    }
}