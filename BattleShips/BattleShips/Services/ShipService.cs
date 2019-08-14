using System;

namespace BattleShips
{
    internal class ShipService
    {
        internal void PlaceShips(ref Cell[,] playerOneBoard, ref Cell[,] playerTwoBoard)
        {
            // Create UserInterface(), show players their boards and let them place their ships.
            UserInterface userInterface = new UserInterface();

            Cell[,] boardHolder;
            bool playerOneTurn = true;

            while (true)
            {
                if (playerOneTurn == true)
                {
                    userInterface.ShowBoard(playerOneBoard);

                    boardHolder = playerOneBoard;
                }
                else
                {
                    userInterface.ShowBoard(playerTwoBoard);

                    boardHolder = playerTwoBoard;
                }

                InputService inputService = new InputService();

                string playerInput = inputService.GetPlayerInput();

                inputService.CheckPlayerInput(playerInput, boardHolder);
            }

            throw new NotImplementedException();
        }
    }
}