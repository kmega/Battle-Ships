using System;
using System.Collections.Generic;

namespace BattleShips
{
    internal class GameEngine
    {
        internal void Start()
        {
            // Create BoardService() and fill two boards with empty cells.
            BoardService boardService = new BoardService();

            Cell[,] playerOneBoard = boardService.CreateNewEmptyBoard();
            Cell[,] playerTwoBoard = boardService.CreateNewEmptyBoard();

            // Create two lists of ships available for placement.
            List<Ship> playerOneShips = new List<Ship>() {
                new Ship(2),
                new Ship(3),
                new Ship(3),
                new Ship(4),
                new Ship(5)
            };
            List<Ship> playerTwoShips = new List<Ship>() {
                new Ship(2),
                new Ship(3),
                new Ship(3),
                new Ship(4),
                new Ship(5)
            };

            // Create ShipService() and let players place their ships.
            ShipService shipService = new ShipService();

            shipService.PlaceShips(ref playerOneBoard, ref playerTwoBoard);

            throw new NotImplementedException();
        }
    }
}