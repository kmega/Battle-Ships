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

            Ship ship = new Ship();

            UI show = new UI();
            string userInput = "";

            while (PlayerOnePlacedAllShips == false)
            {
                show.BoardStatus(PlayerOneBoard);

                Console.WriteLine("\n\nPlayer 1.\nPlace " + ShipCellsNumber + " cell ship using starting coordinates and direction:\n");
                userInput = Console.ReadLine();
                Console.Clear();

                PlayerOneBoard = ship.CreateShip(PlayerOneBoard, userInput);

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

                PlayerTwoBoard = ship.CreateShip(PlayerTwoBoard, userInput);

                if (ShipCellsNumber >= 6)
                {
                    PlayerTwoPlacedAllShips = true;
                    ShipCellsNumber = 2;
                }
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

            Ship ship = new Ship();
            shipCanBeBuild = ship.CheckCellsAroundShip(board, shipCoordinates);

            if (shipCanBeBuild == true)
            {
                board = ship.BuildShip(board, shipCoordinates);
                ShipCellsNumber++;

                return board;
            }
            else
            {
                Console.WriteLine("Ship couldn't be build. It was either: near another ship, placed on another ship or out of board range.");

                return board;
            }
        }
    }
}