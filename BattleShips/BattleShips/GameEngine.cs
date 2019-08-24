using System;
using System.Collections.Generic;

namespace BattleShips
{
    internal class GameEngine
    {
        internal void Start()
        {
            // Create two player instances with board, ships and identification number.
            Player playerOne = new Player(1), playerTwo = new Player(2);

            // Create BoardService() and fill players boards with empty cells.
            BoardService boardService = new BoardService();

            playerOne.board = boardService.CreateNewEmptyBoard();
            playerOne.board = boardService.CreateNewEmptyBoard();

            // Create ShipService() and let players place their ships.
            ShipService shipService = new ShipService();

            shipService.PlaceShips(ref playerOne, ref playerTwo);

            throw new NotImplementedException();
        }
    }
}