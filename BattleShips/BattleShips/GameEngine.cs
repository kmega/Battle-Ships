using System;
using System.Collections.Generic;

namespace BattleShips
{
    internal class GameEngine
    {
        private int ShipCellsNumber = 2;

        internal void Game()
        {
            CellStatus[,] PlayerOneBoard = new CellStatus[10, 10];
            CellStatus[,] PlayerTwoBoard = new CellStatus[10, 10];

            bool PlayerOnePlacedAllShips = false;
            bool PlayerTwoPlacedAllShips = false;

            UI show = new UI();
            string userInput = "";

            while (PlayerOnePlacedAllShips == false)
            {
                show.BoardStatus(PlayerOneBoard);

                Console.WriteLine("\n\nPlayer 1.\nPlace " + ShipCellsNumber + " cell ship using starting coordinates and direction:\n");
                userInput = Console.ReadLine();
                Console.Clear();

                PlayerOneBoard = PlaceShip(PlayerOneBoard, userInput);

                if (ShipCellsNumber >= 6)
                {
                    PlayerOnePlacedAllShips = true;
                    ShipCellsNumber = 2;
                }
            }

            while (PlayerTwoPlacedAllShips == false)
            {
                show.BoardStatus(PlayerTwoBoard);

                Console.WriteLine("\n\nPlayer 2.\nPlace " + ShipCellsNumber + " cell ship using starting coordinates and direction:\n");
                userInput = Console.ReadLine();
                Console.Clear();

                PlayerTwoBoard = PlaceShip(PlayerTwoBoard, userInput);

                if (ShipCellsNumber >= 6)
                {
                    PlayerTwoPlacedAllShips = true;
                    ShipCellsNumber = 2;
                }
            }
        }

        private CellStatus[,] PlaceShip(CellStatus[,] board, string userInput)
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
                board = ModifyBoard(board, coordinates, direction);

                return board;
            }
        }

        internal CellStatus[,] ModifyBoard(CellStatus[,] board, int[] coordinates, string direction)
        {
            List<int[]> shipCoordinates = new List<int[]>();
            bool shipCanBeBuild = false;

            switch (direction)
            {
                case "up":
                    for (int build = 0; build < ShipCellsNumber; build++)
                    {
                        int[] cellCoordinates = new int[] { -1, -1 };

                        cellCoordinates[0] = coordinates[0] - build;
                        cellCoordinates[1] = coordinates[1];

                        shipCoordinates.Add(cellCoordinates);
                    }
                    break;
                case "right":
                    for (int build = 0; build < ShipCellsNumber; build++)
                    {
                        int[] cellCoordinates = new int[] { -1, -1 };

                        cellCoordinates[0] = coordinates[0];
                        cellCoordinates[1] = coordinates[1] + build;

                        shipCoordinates.Add(cellCoordinates);
                    }
                    break;
                case "down":
                    for (int build = 0; build < ShipCellsNumber; build++)
                    {
                        int[] cellCoordinates = new int[] { -1, -1 };

                        cellCoordinates[0] = coordinates[0] + build;
                        cellCoordinates[1] = coordinates[1];

                        shipCoordinates.Add(cellCoordinates);
                    }
                    break;
                case "left":
                    for (int build = 0; build < ShipCellsNumber; build++)
                    {
                        int[] cellCoordinates = new int[] { -1, -1 };

                        cellCoordinates[0] = coordinates[0];
                        cellCoordinates[1] = coordinates[1] - build;

                        shipCoordinates.Add(cellCoordinates);
                    }
                    break;
            }

            shipCanBeBuild = CheckCellsAroundShip(board, shipCoordinates);

            if (shipCanBeBuild == true)
            {
                board = BuildShip(board, shipCoordinates);
                ShipCellsNumber++;

                return board;
            }
            else
            {
                Console.WriteLine("Ship couldn't be build. It was either: near another ship, placed on another ship or out of board range.");

                return board;
            }
        }

        private CellStatus[,] BuildShip(CellStatus[,] board, List<int[]> shipCoordinates)
        {
            int[] coordinates = { -1, -1 };

            for (int i = 0; i < shipCoordinates.Count; i++)
            {
                coordinates = shipCoordinates[i];

                board[coordinates[0], coordinates[1]] = CellStatus.Occupied;
            }

            return board;
        }

        private bool CheckCellsAroundShip(CellStatus[,] board, List<int[]> shipCoordinates)
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