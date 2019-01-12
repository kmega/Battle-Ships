using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleShips;

namespace BattleShipsTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void ShouldReturnUpdatedBoard()
        {
            // For
            CellStatus[,] result = new CellStatus[10, 10];
            int[] coordinates = { 0, 0 };
            string direction = "right";

            // Given
            GameEngine test = new GameEngine();
            CellStatus[,] expectedResult = test.ModifyBoard(result, coordinates, direction);
            result[0, 0] = CellStatus.Occupied;

            // Assert
            Assert.AreEqual(expectedResult[0, 0], result[0, 0]);
        }
    }
}
