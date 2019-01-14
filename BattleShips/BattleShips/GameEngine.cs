using System;
using System.Collections.Generic;

namespace BattleShips
{
    internal class GameEngine
    {
        CellStatus[,] PlayerOneBoard = new CellStatus[10, 10];
        CellStatus[,] PlayerTwoBoard = new CellStatus[10, 10];

        private bool PlayerOnePlacedAllShips = false;
        private bool PlayerTwoPlacedAllShips = false;

        private static readonly List<int> PlayerOneShips = new List<int>
        {
            2, 3, 4, 5
        };
        private static readonly List<int> PlayerTwoShips = new List<int>
        {
            2, 3, 4, 5
        };

        internal void Game()
        {
            while (PlayerOnePlacedAllShips == false)
            {
                PlayerOneBoard = PlaceShips(PlayerOneBoard, PlayerTwoShips, 1);
            }

            Console.WriteLine("\n\nAll ships has been placed. Press anything to continue.");
            Console.ReadKey();

            while (PlayerTwoPlacedAllShips == false)
            {
                PlayerTwoBoard = PlaceShips(PlayerTwoBoard, PlayerOneShips, 2);
            }

            Console.WriteLine("All ships has been placed. Press anything to start the game.\n\n");
            Console.ReadKey();
        }

        private CellStatus[,] PlaceShips(CellStatus[,] board, List<int> shipCellNumber, int playerNumber)
        {
            UI show = new UI();
            string userInput = "";

            show.BoardStatus(PlayerOneBoard, PlayerTwoBoard);

            Console.WriteLine("\n\nPlayer " + playerNumber + ".\nPlace " + shipCellNumber[0] + " cell ship using starting coordinates and direction:\n");
            userInput = Console.ReadLine();
            Console.Clear();

            Ship ship = new Ship();

            board = ship.CreateShip(board, shipCellNumber, userInput);

            if (shipCellNumber.Count == 0 && playerNumber == 1)
            {
                PlayerOnePlacedAllShips = true;
            }
            if (shipCellNumber.Count == 0 && playerNumber == 2)
            {
                PlayerTwoPlacedAllShips = true;
            }

            return board;
        }

        static internal CellStatus[,] ModifyBoard(CellStatus[,] board, List<int> shipCellNumber, int[] coordinates, string direction)
        {
            List<int[]> shipCoordinates = new List<int[]>();
            bool shipCanBeBuild = false;
            int[] cellCoordinates = { -1, -1 };

            for (int build = 0; build < shipCellNumber[0]; build++)
            {
                switch (direction)
                {
                    case "up":
                        cellCoordinates = new int[] { coordinates[0] - build, coordinates[1] };
                        break;
                    case "right":
                        cellCoordinates = new int[] { coordinates[0], coordinates[1] + build };
                        break;
                    case "down":
                        cellCoordinates = new int[] { coordinates[0] + build, coordinates[1] };
                        break;
                    case "left":
                        cellCoordinates = new int[] { coordinates[0], coordinates[1] - build };
                        break;
                }
                shipCoordinates.Add(cellCoordinates);
            }

            Ship ship = new Ship();
            shipCanBeBuild = ship.CheckCellsAroundShip(board, shipCoordinates);

            if (shipCanBeBuild == true)
            {
                board = ship.BuildShip(board, shipCoordinates);
                shipCellNumber.RemoveAt(0);

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