using System.Collections.Generic;

namespace BattleShips
{
    internal class ShipService
    {
        internal void PlaceShips(ref Player playerOne, ref Player playerTwo)
        {
            // Create UserInterface(), show players their boards and let them place their ships.
            UserInterface userInterface = new UserInterface();

            InputService inputService = new InputService();

            bool playerOneTurn = true;

            while (true)
            {
                if (playerOneTurn == true)
                {
                    userInterface.ShowBoard(playerOne.board);

                    inputService.CheckPlayerInput(inputService.GetPlayerInput(), ref playerOne);
                }
                else
                {
                    userInterface.ShowBoard(playerTwo.board);

                    inputService.CheckPlayerInput(inputService.GetPlayerInput(), ref playerTwo);
                }
            }
        }
    }
}