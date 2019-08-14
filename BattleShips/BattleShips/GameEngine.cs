using System;

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

            // Create ShipService() and let players place their ships.
            ShipService shipService = new ShipService();

            shipService.PlaceShips(ref playerOneBoard, ref playerTwoBoard);

            throw new NotImplementedException();
        }
    }
}