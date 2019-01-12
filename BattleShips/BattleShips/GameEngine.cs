using System;

namespace BattleShips
{
    internal class GameEngine
    {
        internal CellStatus[,] PlayerOneBoard = new CellStatus[10, 10];
        internal CellStatus[,] PlayerTwoBoard = new CellStatus[10, 10];

        internal bool PlayerOnePlacedAllShips = false;
        internal bool PlayerTwoPlacedAllShips = false;

        internal void Game()
        {
            UI show = new UI();
            string userInput = "";

            while (PlayerOnePlacedAllShips == false && PlayerTwoPlacedAllShips == false)
            {
                if (PlayerOnePlacedAllShips == false)
                {
                    show.BoardStatus(PlayerOneBoard);

                    Console.WriteLine("\n\nPlayer 1.\nPlace ship x using cell coordinates and direction:");
                    userInput = Console.ReadLine();

                    PlayerOneBoard = PlaceShip(PlayerOneBoard, userInput);
                }
                else
                {
                    show.BoardStatus(PlayerTwoBoard);

                    Console.WriteLine("\n\nPlayer 2.\nPlace ship x using cell coordinates and direction:");
                    userInput = Console.ReadLine();

                    PlayerTwoBoard = PlaceShip(PlayerTwoBoard, userInput);
                }
            }
        }

        private CellStatus[,] PlaceShip(CellStatus[,] board, string userInput)
        {
            CheckInput check = new CheckInput();
            int[] coordinates = check.UserCoordinates(userInput);
            string direction = check.UserDirection(userInput);

            if (coordinates[0] == -1 || coordinates[1] == -1)
            {
                Console.WriteLine("Wrong input!\n\n");
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
                        board[i, j] = CellStatus.Occupied;
                    }
                }
            }

            return board;
        }
    }
}