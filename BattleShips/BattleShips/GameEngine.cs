using System;

namespace BattleShips
{
    internal class GameEngine
    {
        internal void Start()
        {
            // Create two player instances with board and ships.
            Player playerOne = new Player(), playerTwo = new Player();

            // Create BoardService() and fill players boards and dummy boards with empty cells.
            BoardService boardService = new BoardService();

            playerOne.board = boardService.CreateNewEmptyBoard();
            playerTwo.board = boardService.CreateNewEmptyBoard();

            playerOne.dummyBoard = boardService.CreateNewEmptyBoard();
            playerTwo.dummyBoard = boardService.CreateNewEmptyBoard();

            // Create ShipService() and let players place their ships.
            ShipService shipService = new ShipService();

            shipService.PlaceShips(ref playerOne, ref playerTwo);

            // Start the battle.
            boardService.StartBattle(ref playerOne, ref playerTwo);

            throw new NotImplementedException();
        }
    }
}