using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips
{
    class Ship
    {
        internal CellStatus[,] CreateShip(CellStatus[,] board, List<int> shipCellNumber, string userInput)
        {
            CheckInput check = new CheckInput();
            int[] coordinates = check.UserCoordinates(userInput);
            string direction = check.UserDirection(userInput);

            if (coordinates[0] == -1 || coordinates[1] == -1 || direction == null)
            {
                Console.WriteLine("Wrong input!\n");

                return board;
            }
            else
            {
                board = GameEngine.ModifyBoard(board, shipCellNumber, coordinates, direction);

                return board;
            }
        }

        internal CellStatus[,] BuildShip(CellStatus[,] board, List<int[]> shipCoordinates)
        {
            int[] coordinates = { -1, -1 };

            for (int i = 0; i < shipCoordinates.Count; i++)
            {
                coordinates = shipCoordinates[i];

                board[coordinates[0], coordinates[1]] = CellStatus.Occupied;
            }

            return board;
        }

        internal bool CheckCellsAroundShip(CellStatus[,] board, List<int[]> shipCoordinates)
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
    }
}
