using System;

namespace BattleShips
{
    internal class BoardService
    {
        internal Cell[,] CreateNewEmptyBoard()
        {
            // Create an array of 10x10, fill it with empty cells and then return it.
            Cell[,] newBoard = new Cell[10, 10];

            for (int i = 0; i < newBoard.GetLength(0); i++)
            {
                for (int j = 0; j < newBoard.GetLength(1); j++)
                {
                    newBoard[i, j] = Cell.Empty;
                }
            }

            return newBoard;
        }

        internal void PlaceShipOnBoard(int[] convertedInput, ref Player player)
        {
            // Place ship on board using prepared coordinates.
            Ship ship = player.ships[player.shipIndex];

            foreach (var coordinates in ship.coordinates)
            {
                player.board[coordinates[0], coordinates[1]] = Cell.Occupied;
            }

            // Increment shipIndex to place a different ship.
            player.shipIndex++;
        }

        internal void StartBattle(ref Player playerOne, ref Player playerTwo)
        {
            // Battle until one of the players loses all ships.
            InputService inputService = new InputService();

            bool playerOneTurn = true;

            while (playerOne.ships.Count == 0 || playerTwo.ships.Count == 0)
            {
                if (playerOneTurn == true)
                {
                    ShootAtEnemyBoard(inputService.ConvertPlayerInput(inputService.GetPlayerInput()), ref playerOne, ref playerTwo);

                    playerOneTurn = false;
                }
                else
                {
                    ShootAtEnemyBoard(inputService.ConvertPlayerInput(inputService.GetPlayerInput()), ref playerTwo, ref playerOne);

                    playerOneTurn = true;
                }
            }
        }

        private void ShootAtEnemyBoard(int[] attackerInput, ref Player attacker, ref Player defender)
        {
            
        }
    }
}