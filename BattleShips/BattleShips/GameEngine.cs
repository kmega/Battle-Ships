using System;
using System.Collections.Generic;

namespace BattleShips
{
    internal class GameEngine
    {
        private static CellStatus[,] PlayerOneBoard = new CellStatus[10, 10];
        private static CellStatus[,] PlayerTwoBoard = new CellStatus[10, 10];

        private static CellStatus[,] PlayerOneOverlay = new CellStatus[10, 10];
        private static CellStatus[,] PlayerTwoOverlay = new CellStatus[10, 10];

        private static bool PlayerOnePlacedAllShips = false;
        private static bool PlayerTwoPlacedAllShips = false;

        private static readonly List<int> PlayerOneShips = new List<int>
        {
            2, 3, 4, 5
        };
        private static readonly List<int> PlayerTwoShips = new List<int>
        {
            2, 3, 4, 5
        };

        private static readonly List<List<int[]>> PlayerOneShipsPositions = new List<List<int[]>>();
        private static readonly List<List<int[]>> PlayerTwoShipsPositions = new List<List<int[]>>();

        private static bool Winner = false;
        private static int PlayerTurn = 1;

        internal void Game()
        {
            while (PlayerOnePlacedAllShips == false)
            {
                PlayerOneBoard = PlaceShips(PlayerOneBoard, PlayerTwoShips, 1);
            }

            Console.WriteLine("\n\nAll ships has been placed. Press anything to continue.");
            Console.ReadKey();
            Console.Clear();

            while (PlayerTwoPlacedAllShips == false)
            {
                PlayerTwoBoard = PlaceShips(PlayerTwoBoard, PlayerOneShips, 2);
            }

            Console.WriteLine("\n\nAll ships has been placed. Press anything to start the game.");
            Console.ReadKey();
            Console.Clear();

            while (Winner == false)
            {
                if (PlayerTurn == 1)
                {
                    PlayerTwoOverlay = BattleStatus(PlayerTwoBoard, PlayerTwoOverlay);
                    if (Winner == false)
                    {
                        PlayerTurn = 2;
                    }
                }
                else
                {
                    PlayerOneOverlay = BattleStatus(PlayerOneBoard, PlayerOneOverlay);
                    if (Winner == false)
                    {
                        PlayerTurn = 1;
                    }
                }
            }
        }

        private static CellStatus[,] BattleStatus(CellStatus[,] enemyPlayerBoard, CellStatus[,] strategicOverlay)
        {
            string input = "";
            int[] coordinates = { -1, -1 };

            while (coordinates[0] == -1 || coordinates[1] == -1)
            {
                if (PlayerTurn == 1)
                {
                    UI.BoardStatus(PlayerOneBoard, strategicOverlay);
                }
                else
                {
                    UI.BoardStatus(strategicOverlay, PlayerTwoBoard);
                }

                Console.WriteLine("\n\nPlayer " + PlayerTurn + ". Shoot at cell using it's coordinates:");
                input = Console.ReadLine();
                Console.Clear();

                coordinates = CheckInput.UserCoordinates(input);
            }

            if (enemyPlayerBoard[coordinates[0], coordinates[1]] == CellStatus.Occupied)
            {
                strategicOverlay[coordinates[0], coordinates[1]] = CellStatus.Hit;
                enemyPlayerBoard[coordinates[0], coordinates[1]] = CellStatus.Hit;
            }
            else
            {
                strategicOverlay[coordinates[0], coordinates[1]] = CellStatus.Fired;
                enemyPlayerBoard[coordinates[0], coordinates[1]] = CellStatus.Fired;
            }

            CheckCellsStatus(enemyPlayerBoard);

            return strategicOverlay;
        }

        private static void CheckCellsStatus(CellStatus[,] enemyPlayerBoard)
        {
            int counter = 0;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (enemyPlayerBoard[i, j] == CellStatus.Occupied)
                    {
                        counter++;
                    }
                }
            }

            if (counter == 0)
            {
                Winner = true;
            }
        }

        private CellStatus[,] PlaceShips(CellStatus[,] board, List<int> shipCellNumber, int playerNumber)
        {
            if (playerNumber == 1)
            {
                UI.BoardStatus(PlayerOneBoard, PlayerTwoOverlay);
            }
            else
            {
                UI.BoardStatus(PlayerOneOverlay, PlayerTwoBoard);
            }

            Console.WriteLine("\n\nPlayer " + playerNumber + ".\nPlace " + shipCellNumber[0] + " cell ship using starting coordinates and direction:");
            string userInput = Console.ReadLine();

            Console.Clear();

            board = Ship.CreateShip(board, shipCellNumber, userInput, playerNumber);

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

        static internal CellStatus[,] ModifyBoard(CellStatus[,] board, List<int> shipCellNumber, int[] coordinates, string direction, int playerNumber)
        {
            List<int[]> shipCoordinates = new List<int[]>();
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

            if (playerNumber == 1)
            {
                PlayerOneShipsPositions.Add(shipCoordinates);
            }
            else
            {
                PlayerTwoShipsPositions.Add(shipCoordinates);
            }

            bool shipCanBeBuild = Ship.CheckCellsAroundShip(board, shipCoordinates);

            if (shipCanBeBuild == true)
            {
                board = Ship.BuildShip(board, shipCoordinates);
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