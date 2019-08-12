using System;

namespace BattleShips
{
    internal class GameEngine
    {
        internal void Start()
        {
            BoardService boardService = new BoardService();

            CellStatus[,] playerOneBoard = boardService.CreateNewEmptyBoard();
            CellStatus[,] playerTwoBoard = boardService.CreateNewEmptyBoard();

            ShipService shipService = new ShipService();

            shipService.PlaceShips(ref playerOneBoard, ref playerTwoBoard);

            throw new NotImplementedException();
        }
    }
}