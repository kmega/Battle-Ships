using System;
using System.Collections.Generic;

namespace BattleShips
{
    class Ship
    {
        internal static CellStatus[,] CreateShip(CellStatus[,] board, List<int> shipCellNumber, string userInput, int playerNumber)
        {
            string direction = CheckInput.UserDirection(userInput);
            int[] coordinates = CheckInput.UserCoordinates(userInput);

            if (coordinates[0] == -1 || coordinates[1] == -1 || direction == null)
            {
                Console.WriteLine("Wrong input!\n");

                return board;
            }
            else
            {
                board = GameEngine.ModifyBoard(board, shipCellNumber, coordinates, direction, playerNumber);

                return board;
            }
        }

        internal static CellStatus[,] BuildShip(CellStatus[,] board, List<int[]> shipCoordinates)
        {
            int[] coordinates = { -1, -1 };

            for (int i = 0; i < shipCoordinates.Count; i++)
            {
                coordinates = shipCoordinates[i];

                board[coordinates[0], coordinates[1]] = CellStatus.Occupied;
            }

            return board;
        }

        internal static bool CheckCellsAroundShip(CellStatus[,] board, List<int[]> shipCoordinates)
        {
            int[] coordinates = { -1, -1 };

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    for (int k = 0; k < shipCoordinates.Count; k++)
                    {
                        coordinates = shipCoordinates[k];

                        try
                        {
                            if (board[coordinates[0] + i, coordinates[1] + j] != CellStatus.Empty)
                            {
                                return false;
                            }
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }
            }

            for (int i = 0; i < shipCoordinates.Count; i++)
            {
                coordinates = shipCoordinates[i];

                try
                {
                    board[coordinates[0], coordinates[1]] = CellStatus.Empty;
                }
                catch
                {
                    return false;
                }
            }

            return true;
        }

        internal static CellStatus[,] CheckIfShipIsDestoyed(CellStatus[,] enemyPlayerBoard, CellStatus[,] strategicOverlay, List<List<int[]>> shipPositions)
        {
            int[] coordinates = { -1, -1 };
            int numberOfCellsDestoyed = 0;
            bool shipDestroyed = false;

            for (int i = 0; i < shipPositions.Count; i++)
            {
                for (int j = 0; j < shipPositions[i].Count; j++)
                {
                    coordinates = shipPositions[i][j];

                    try
                    {
                        if (enemyPlayerBoard[coordinates[0], coordinates[1]] == CellStatus.Hit)
                        {
                            numberOfCellsDestoyed++;
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }

                if (numberOfCellsDestoyed == shipPositions[i].Count && shipDestroyed == false)
                {
                    strategicOverlay = DestroyShip(enemyPlayerBoard, strategicOverlay, shipPositions[i]);
                    shipDestroyed = true;
                }
            }

            return strategicOverlay;
        }

        internal static CellStatus[,] DestroyShip(CellStatus[,] enemyPlayerBoard, CellStatus[,] strategicOverlay, List<int[]> shipCoordinates)
        {
            int[] destroyCell = { -1, -1 };

            for (int i = 0; i < shipCoordinates.Count; i++)
            {
                destroyCell = shipCoordinates[i];

                for (int row = -1; row <= 1; row++)
                {
                    for (int column = -1; column <= 1; column++)
                    {
                        try
                        {
                            enemyPlayerBoard[destroyCell[0] + row, destroyCell[1] + column] = CellStatus.Blocked;
                            strategicOverlay[destroyCell[0] + row, destroyCell[1] + column] = CellStatus.Blocked;
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }
            }

            return strategicOverlay;
        }
    }
}
