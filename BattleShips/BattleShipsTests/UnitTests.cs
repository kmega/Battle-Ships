using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleShips;
using System.Collections.Generic;

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
            List<int> shipCellNumber = new List<int>
            {
                1
            };

            // Given
            CellStatus[,] expectedResult = GameEngine.ModifyBoard(result, shipCellNumber, coordinates, direction, 1);
            result[0, 0] = CellStatus.Occupied;

            // Assert
            Assert.AreEqual(expectedResult[0, 0], result[0, 0]);
        }
    }
}
