using System.Collections.Generic;

namespace BattleShips
{
    internal class ShipService
    {
        internal void PlaceShips(ref Cell[,] playerOneBoard, ref Cell[,] playerTwoBoard)
        {
            // Create UserInterface(), show players their boards and let them place their ships.
            UserInterface userInterface = new UserInterface();

            InputService inputService = new InputService();

            bool playerOneTurn = true;

            while (true)
            {
                if (playerOneTurn == true)
                {
                    userInterface.ShowBoard(playerOneBoard);

                    inputService.CheckPlayerInput(inputService.GetPlayerInput(), ref playerOneBoard);

                    playerOneTurn = false;
                }
                else
                {
                    userInterface.ShowBoard(playerTwoBoard);

                    inputService.CheckPlayerInput(inputService.GetPlayerInput(), ref playerTwoBoard);

                    playerOneTurn = true;
                }
            }
        }
    }
}