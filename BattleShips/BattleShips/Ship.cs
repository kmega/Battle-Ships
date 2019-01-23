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
                Console.WriteLine("\n Wrong input!\n");

                return board;
            }
            else
            {
                board = GameEngine.ModifyBoard(board, shipCellNumber, coordinates, direction, playerNumber);

                return board;
            }
        }

        internal static CellStatus[,] BuildShip(CellStatus[,] board, List<int[]> shipsCoordinates)
        {
            int[] coordinates = { -1, -1 };

            for (int i = 0; i < shipsCoordinates.Count; i++)
            {
                coordinates = shipsCoordinates[i];

                board[coordinates[0], coordinates[1]] = CellStatus.Occupied;
            }

            return board;
        }

        internal static bool CheckCellsAroundShip(CellStatus[,] board, List<int[]> shipsCoordinates)
        {
            int[] coordinates = { -1, -1 };

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    for (int k = 0; k < shipsCoordinates.Count; k++)
                    {
                        coordinates = shipsCoordinates[k];

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

            for (int i = 0; i < shipsCoordinates.Count; i++)
            {
                coordinates = shipsCoordinates[i];

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

        internal static List<int[]> CheckIfShipIsDestoyed(CellStatus[,] enemyPlayerBoard, CellStatus[,] strategicOverlay, List<List<int[]>> shipsPositions)
        {
            int[] coordinates = { -1, -1 };
            int numberOfCellsDestoyed = 0;
            bool shipDestroyed = false;
            List<int[]> shipCoordinates = new List<int[]>();

            for (int index = 0; index < shipsPositions.Count; index++)
            {
                for (int position = 0; position < shipsPositions[index].Count; position++)
                {
                    coordinates = shipsPositions[index][position];

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

                if (numberOfCellsDestoyed == shipsPositions[index].Count && shipDestroyed == false)
                {
                    shipCoordinates = shipsPositions[index];

                    shipDestroyed = true;
                }
            }

            return shipCoordinates;
        }

        internal static CellStatus[,] DestroyShip(CellStatus[,] enemyPlayerBoard, CellStatus[,] strategicOverlay, List<int[]> shipCoordinates)
        {
            int[] destroyCell = { -1, -1 };

            for (int index = 0; index < shipCoordinates.Count; index++)
            {
                destroyCell = shipCoordinates[index];

                for (int column = -1; column <= 1; column++)
                {
                    for (int row = -1; row <= 1; row++)
                    {
                        try
                        {
                            enemyPlayerBoard[destroyCell[0] + column, destroyCell[1] + row] = CellStatus.Blocked;
                            strategicOverlay[destroyCell[0] + column, destroyCell[1] + row] = CellStatus.Blocked;
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
