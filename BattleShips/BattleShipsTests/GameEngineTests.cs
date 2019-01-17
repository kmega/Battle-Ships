using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleShips;
using System.Collections.Generic;

namespace BattleShipsTests
{
    [TestClass]
    public class GameEngineTests
    {

        [TestMethod]
        public void ShouldUpdateBoardWhenInputIsValid()
        {
            // For
            CellStatus[,] board = new CellStatus[10, 10];
            int[] coordinates = { 0, 0 };
            string direction = "right";

            List<int> shipCellNumber = new List<int>
            {
                3
            };

            // Given
            CellStatus[,] expectedResult = GameEngine.ModifyBoard(board, shipCellNumber, coordinates, direction, 1);

            // Assert
            for (int row = 0; row < 3; row++)
            {
                Assert.IsTrue(expectedResult[0, row] == board[0, row]);
            }
        }

        [TestMethod]
        public void ShouldNotUpdateBoardWhenDirectionIsNotValid()
        {
            // For
            CellStatus[,] board = new CellStatus[10, 10];
            int[] coordinates = { 0, 0 };
            string direction = "left";

            List<int> shipCellNumber = new List<int>
            {
                3
            };

            // Given
            CellStatus[,] expectedResult = GameEngine.ModifyBoard(board, shipCellNumber, coordinates, direction, 1);

            // Assert
            for (int row = 0; row < 3; row++)
            {
                Assert.IsTrue(expectedResult[0, row] == board[0, row]);
            }
        }

        [TestMethod]
        public void ShouldNotUpdateBoardWhenCoordinatesAreNotValid()
        {
            // For
            CellStatus[,] board = new CellStatus[10, 10];
            int[] coordinates = { -1, -1 };
            string direction = "right";

            List<int> shipCellNumber = new List<int>
            {
                3
            };

            // Given
            CellStatus[,] expectedResult = GameEngine.ModifyBoard(board, shipCellNumber, coordinates, direction, 1);

            // Assert
            for (int row = 0; row < 3; row++)
            {
                Assert.IsTrue(expectedResult[0, row] == board[0, row]);
            }
        }

        [TestMethod]
        public void ShouldCheckForOccupiedCellsAndSwitchToFalseWhenAtLeastOneIsPresent()
        {
            // For
            CellStatus[,] board = new CellStatus[10, 10];
            board[0, 0] = CellStatus.Occupied;

            // Given
            GameEngine.CheckCellsStatus(board);

            // Assert
            Assert.IsTrue(GameEngine.Winner == false);
        }

        [TestMethod]
        public void ShouldCheckForOccupiedCellsAndSwitchToTrueWhenNoneArePresent()
        {
            // For
            CellStatus[,] board = new CellStatus[10, 10];

            // Given
            GameEngine.CheckCellsStatus(board);

            // Assert
            Assert.IsTrue(GameEngine.Winner == true);
        }
    }
}
