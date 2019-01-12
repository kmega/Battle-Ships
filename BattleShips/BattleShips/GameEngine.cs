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

                    PlayerOneBoard = PlaceShip(userInput);
                }
                else
                {
                    show.BoardStatus(PlayerTwoBoard);

                    Console.WriteLine("\n\nPlayer 2.\nPlace ship x using cell coordinates and direction:");
                    userInput = Console.ReadLine();

                    PlayerTwoBoard = PlaceShip(userInput);
                }
            }
        }

        private CellStatus[,] PlaceShip(string userInput)
        {
            CheckInput check = new CheckInput();
            return null;
        }
    }
}