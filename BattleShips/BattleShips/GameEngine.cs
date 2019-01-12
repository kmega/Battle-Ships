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

            while (PlayerOnePlacedAllShips == false && PlayerTwoPlacedAllShips == false)
            {
                if (PlayerOnePlacedAllShips == false)
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
                else
                {
                    show.BoardStatus(PlayerTwoBoard);

                    Console.WriteLine("\n\nPlayer 2.\nPlace" + ShipCellsNumber + " cell ship using starting coordinates and direction:\n");
                    userInput = Console.ReadLine();
                    Console.Clear();

                    PlayerTwoBoard = PlaceShip(PlayerTwoBoard, userInput);

                    if (ShipCellsNumber >= 6)
                    {
                        PlayerTwoPlacedAllShips = true;
                        ShipCellsNumber = 2;
                    }
                }

                Console.WriteLine("");
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
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (i == coordinates[0] && j == coordinates[1])
                    {
                        switch (direction)
                        {
                            case "up":
                                for (int build = 0; build < ShipCellsNumber; build++)
                                {
                                    board[i - build, j] = CellStatus.Occupied;
                                }
                                break;
                            case "right":
                                for (int build = 0; build < ShipCellsNumber; build++)
                                {
                                    board[i, j + build] = CellStatus.Occupied;
                                }
                                break;
                            case "down":
                                for (int build = 0; build < ShipCellsNumber; build++)
                                {
                                    board[i + build, j] = CellStatus.Occupied;
                                }
                                break;
                            case "left":
                                for (int build = 0; build < ShipCellsNumber; build++)
                                {
                                    board[i, j - build] = CellStatus.Occupied;
                                }
                                break;
                        }
                    }
                }
            }

            return board;
        }
    }
}