using System;

namespace BattleShips
{
    internal class ShipService
    {
        internal void PlaceShips(ref CellStatus[,] playerOneBoard, ref CellStatus[,] playerTwoBoard)
        {
            UserInterface userInterface = new UserInterface();

            userInterface.ShowBoard(playerOneBoard);

            throw new NotImplementedException();
        }
    }
}