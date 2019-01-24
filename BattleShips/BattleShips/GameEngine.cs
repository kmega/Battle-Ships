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
            2//2, 3, 3, 4, 5
        };
        private static readonly List<int> PlayerTwoShips = new List<int>
        {
            2//2, 3, 3, 4, 5
        };

        private static readonly List<List<int[]>> PlayerOneShipsPositions = new List<List<int[]>>();
        private static readonly List<List<int[]>> PlayerTwoShipsPositions = new List<List<int[]>>();

        internal static bool Winner = false;
        private static int PlayerTurn = 1;

        internal static void StartBattleShips()
        {
            while (PlayerOnePlacedAllShips == false)
            {
                PlayerOneBoard = PlaceShips(PlayerOneBoard, PlayerTwoShips, 1);
            }
            ClickToContinue(PlayerOneBoard, 1, "Press anything to continue.\n");

            while (PlayerTwoPlacedAllShips == false)
            {
                PlayerTwoBoard = PlaceShips(PlayerTwoBoard, PlayerOneShips, 2);
            }
            ClickToContinue(PlayerTwoBoard, 2, "Press anything to start the game.\n");

            string playerNumber;
            while (Winner == false)
            {
                if (PlayerTurn == 1)
                {
                    PlayerTwoOverlay = BattleStatus(PlayerTwoBoard, PlayerTwoOverlay, PlayerTwoShipsPositions);
                    if (Winner == false)
                    {
                        PlayerTurn = 2;
                    }
                }
                else
                {
                    PlayerOneOverlay = BattleStatus(PlayerOneBoard, PlayerOneOverlay, PlayerOneShipsPositions);
                    if (Winner == false)
                    {
                        PlayerTurn = 1;
                    }
                }
            }

            if (PlayerTurn == 1)
            {
                playerNumber = "One";
            }
            else
            {
                playerNumber = "Two";
            }

            Console.Clear();
            Console.WriteLine("\n Player " + playerNumber + " has WON the battle! Press anything to quit.\n");
            Console.Write(" ");
        }

        private static void ClickToContinue(CellStatus[,] board, int playerNumber, string message)
        {
            UI.BoardStatus(board, 0, playerNumber);
            Console.WriteLine("\n All ships has been placed. " + message);
            Console.Write(" ");
            Console.ReadKey();
            Console.Clear();
        }

        private static CellStatus[,] BattleStatus(CellStatus[,] enemyPlayerBoard, CellStatus[,] strategicOverlay, List<List<int[]>> shipPositions)
        {
            ConsoleColor playerColor;
            bool wasFiredUpon = true;
            string input = "", playerNumber;
            int[] coordinates = { -1, -1 };
            List<int[]> coordinatesForDestruction = new List<int[]>();

            while (coordinates[0] == -1 || coordinates[1] == -1 || wasFiredUpon == true)
            {
                if (PlayerTurn == 1)
                {
                    UI.BoardStatus(strategicOverlay, PlayerTwoShipsPositions.Count, 1);
                    playerNumber = "One";
                    playerColor = ConsoleColor.Green;
                }
                else
                {
                    UI.BoardStatus(strategicOverlay, PlayerOneShipsPositions.Count, 2);
                    playerNumber = "Two";
                    playerColor = ConsoleColor.Cyan;
                }

                Console.WriteLine("\n Shoot at cell using it's coordinates:\n");
                Console.Write(" ");
                input = Console.ReadLine();
                Console.Clear();

                coordinates = CheckInput.UserCoordinates(input);

                try
                {
                    if (enemyPlayerBoard[coordinates[0], coordinates[1]] == CellStatus.Fired || enemyPlayerBoard[coordinates[0], coordinates[1]] == CellStatus.Hit || enemyPlayerBoard[coordinates[0], coordinates[1]] == CellStatus.Blocked)
                    {
                        Console.WriteLine("\n You already fired at those coordinates! Who made you an Admiral?!\n");

                        wasFiredUpon = true;
                    }
                    else
                    {
                        Console.ForegroundColor = playerColor;

                        if (enemyPlayerBoard[coordinates[0], coordinates[1]] == CellStatus.Occupied)
                        {
                            strategicOverlay[coordinates[0], coordinates[1]] = CellStatus.Hit;
                            enemyPlayerBoard[coordinates[0], coordinates[1]] = CellStatus.Hit;

                            wasFiredUpon = false;

                            Console.Write("\n Player " + playerNumber + ": ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("TARGET HIT!\n");
                        }
                        else
                        {
                            strategicOverlay[coordinates[0], coordinates[1]] = CellStatus.Fired;
                            enemyPlayerBoard[coordinates[0], coordinates[1]] = CellStatus.Fired;

                            wasFiredUpon = false;

                            Console.Write("\n Player " + playerNumber + ": ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("SHOOT MISSED!\n");
                        }

                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                catch
                {
                    Console.WriteLine("\n Wrong coordinates!\n");
                }
            }

            coordinatesForDestruction = Ship.CheckIfShipIsDestoyed(enemyPlayerBoard, strategicOverlay, shipPositions);

            if (coordinatesForDestruction.Count > 0)
            {
                strategicOverlay = Ship.DestroyShip(enemyPlayerBoard, strategicOverlay, coordinatesForDestruction);

                for (int index = 0; index < shipPositions.Count; index++)
                {
                    if (coordinatesForDestruction == shipPositions[index])
                    {
                        shipPositions.RemoveAt(index);
                    }
                }
            }

            CheckCellsStatus(enemyPlayerBoard);

            return strategicOverlay;
        }

        internal static void CheckCellsStatus(CellStatus[,] enemyPlayerBoard)
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

        private static CellStatus[,] PlaceShips(CellStatus[,] board, List<int> shipCellNumber, int playerNumber)
        {
            if (playerNumber == 1)
            {
                UI.BoardStatus(PlayerOneBoard, 0, 1);
            }
            else
            {
                UI.BoardStatus(PlayerTwoBoard, 0, 2);
            }

            Console.WriteLine("\n Place " + shipCellNumber[0] + " cell ship using starting coordinates and direction:\n");
            Console.Write(" ");
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

        internal static CellStatus[,] ModifyBoard(CellStatus[,] board, List<int> shipCellNumber, int[] coordinates, string direction, int playerNumber)
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
                Console.WriteLine("\n Ship couldn't be build. It was either: near another ship, placed on another ship or out of board range.");

                return board;
            }
        }
    }
}