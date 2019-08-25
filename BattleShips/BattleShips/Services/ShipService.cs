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

        internal void PlaceShipOnBoard(int[] convertedInput, ref Player player)
        {
            Ship ship = player.ships[player.shipIndex];

            foreach (var coordinates in ship.coordinates)
            {
                player.board[coordinates[0], coordinates[1]] = Cell.Occupied;
            }

            player.shipIndex++;
        }
    }
}