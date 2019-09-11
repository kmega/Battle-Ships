using BattleShips;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BattleShipsUnitTest
{
    [TestClass]
    public class BoardServiceUnitTest
    {
        [TestMethod]
        public void ShouldCreateEmptyBoard()
        {
            // For
            Player player = new Player();

            BoardService boardService = new BoardService();

            Cell[,] expectedResult = boardService.CreateNewEmptyBoard();

            CollectionAssert.AreNotEqual(player.board, expectedResult);

            // Given
            player.board = boardService.CreateNewEmptyBoard();

            // Assert
            CollectionAssert.AreEqual(player.board, expectedResult);
        }
    }

    [TestClass]
    public class CheckingServiceUnitTest
    {
        [TestMethod]
        public void ShouldCheckBoardBoundaries()
        {
            // For
            Player player = new Player();

            CheckingService checkingService = new CheckingService();

            // Given
            bool expectedResult = false, result = checkingService.CheckBoardBoundaries(new int[] { 0, 0, 3 }, ref player);

            // Assert
            Assert.IsTrue(expectedResult == result);
        }
    }
}
