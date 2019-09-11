namespace BattleShips
{
    internal class ShipService
    {
        internal void PlaceShips(ref Player playerOne, ref Player playerTwo)
        {
            // Create UserInterface() and InputService(), show players their boards and let them place their ships.
            UserInterface userInterface = new UserInterface();

            InputService inputService = new InputService();

            bool playerOneTurn = true;

            while (playerOne.shipIndex != 5 && playerTwo.shipIndex != 5)
            {
                // Change to player two if all ships were placed by player one.
                if (playerOne.shipIndex == 5)
                {
                    playerOneTurn = false;
                }

                if (playerOneTurn == true)
                {
                    userInterface.ShowBoard(playerOne.board);

                    // Check input of player one before placing ship.
                    inputService.CheckPlayerInput(inputService.GetPlayerInput(), ref playerOne);
                }
                else
                {
                    userInterface.ShowBoard(playerTwo.board);

                    // Check input of player two before placing ship.
                    inputService.CheckPlayerInput(inputService.GetPlayerInput(), ref playerTwo);
                }
            }
        }
    }
}