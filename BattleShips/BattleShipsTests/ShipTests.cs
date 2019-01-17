using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleShips;
using System.Collections.Generic;

namespace BattleShipsTests
{
    [TestClass]
    public class ShipTests
    {
        [TestMethod]
        public void ShouldCreateShipWhenInputIsValid()
        {
            // For
            CellStatus[,] board = new CellStatus[10, 10];
            string userInput = "a1 right";

            List<int> shipCellNumber = new List<int>
            {
                3
            };

            // Given
            CellStatus[,] expectedResult = Ship.CreateShip(board, shipCellNumber, userInput, 1);

            // Assert
            for (int row = 0; row < 3; row++)
            {
                Assert.IsTrue(expectedResult[0, row] == board[0, row]);
            }
        }

        [TestMethod]
        public void ShouldNotCreateShipWhenDirectionIsNotValid()
        {
            // For
            CellStatus[,] board = new CellStatus[10, 10];
            string userInput = "a1 left";

            List<int> shipCellNumber = new List<int>
            {
                3
            };

            // Given
            CellStatus[,] expectedResult = Ship.CreateShip(board, shipCellNumber, userInput, 1);

            // Assert
            for (int row = 0; row < 3; row++)
            {
                Assert.IsTrue(expectedResult[0, row] == board[0, row]);
            }
        }

        [TestMethod]
        public void ShouldNotCreateShipWhenCoordinatesAreNotValid()
        {
            // For
            CellStatus[,] board = new CellStatus[10, 10];
            string userInput = "z1 right";

            List<int> shipCellNumber = new List<int>
            {
                3
            };

            // Given
            CellStatus[,] expectedResult = Ship.CreateShip(board, shipCellNumber, userInput, 1);

            // Assert
            for (int row = 0; row < 3; row++)
            {
                Assert.IsTrue(expectedResult[0, row] == board[0, row]);
            }
        }

        [TestMethod]
        public void ShouldCheckAroundShipCellsAndReturnTrueWhenShipIsInBoardRange()
        {
            // For
            CellStatus[,] board = new CellStatus[10, 10];

            int[] firstCoordinates = { 0, 0 };
            int[] secondCoordinates = { 0, 1 };
            int[] thirdCoordinates = { 0, 2 };

            List<int[]> shipCoordinates = new List<int[]>
            {
                firstCoordinates, secondCoordinates, thirdCoordinates
            };

            // Given
            bool expectedResult = Ship.CheckCellsAroundShip(board, shipCoordinates);

            // Assert
            for (int row = 0; row < 3; row++)
            {
                Assert.IsTrue(expectedResult == true);
            }
        }

        [TestMethod]
        public void ShouldCheckAroundShipCellsAndReturnFalseWhenShipIsNearAnotherShip()
        {
            // For
            CellStatus[,] board = new CellStatus[10, 10];

            for (int row = 0; row < 3; row++)
            {
                board[1, row] = CellStatus.Occupied;
            }

            int[] firstCoordinates = { 0, 0 };
            int[] secondCoordinates = { 0, 1 };
            int[] thirdCoordinates = { 0, 2 };

            List<int[]> shipCoordinates = new List<int[]>
            {
                firstCoordinates, secondCoordinates, thirdCoordinates
            };

            // Given
            bool expectedResult = Ship.CheckCellsAroundShip(board, shipCoordinates);

            // Assert
            for (int row = 0; row < 3; row++)
            {
                Assert.IsTrue(expectedResult == false);
            }
        }

        [TestMethod]
        public void ShouldCheckAroundShipCellsAndReturnFalseWhenShipIsBeingBuiltOnAnotherShip()
        {
            // For
            CellStatus[,] board = new CellStatus[10, 10];

            for (int column = 0; column < 3; column++)
            {
                board[column, 0] = CellStatus.Occupied;
            }

            int[] firstCoordinates = { 0, 0 };
            int[] secondCoordinates = { 0, 1 };
            int[] thirdCoordinates = { 0, 2 };

            List<int[]> shipCoordinates = new List<int[]>
            {
                firstCoordinates, secondCoordinates, thirdCoordinates
            };

            // Given
            bool expectedResult = Ship.CheckCellsAroundShip(board, shipCoordinates);

            // Assert
            for (int row = 0; row < 3; row++)
            {
                Assert.IsTrue(expectedResult == false);
            }
        }

        [TestMethod]
        public void ShouldCheckAroundShipCellsAndReturnFalseWhenShipIsNotInBoardRange()
        {
            // For
            CellStatus[,] board = new CellStatus[10, 10];

            int[] firstCoordinates = { 0, -1 };
            int[] secondCoordinates = { 0, 0 };
            int[] thirdCoordinates = { 0, 1 };

            List<int[]> shipCoordinates = new List<int[]>
            {
                firstCoordinates, secondCoordinates, thirdCoordinates
            };

            // Given
            bool expectedResult = Ship.CheckCellsAroundShip(board, shipCoordinates);

            // Assert
            for (int row = 0; row < 3; row++)
            {
                Assert.IsTrue(expectedResult == false);
            }
        }

        [TestMethod]
        public void ShouldBuildShipWhenCoordinatesAreValid()
        {
            // For
            CellStatus[,] board = new CellStatus[10, 10];

            int[] firstCoordinates = { 0, 0 };
            int[] secondCoordinates = { 0, 1 };
            int[] thirdCoordinates = { 0, 2 };

            List<int[]> shipCoordinates = new List<int[]>
            {
                firstCoordinates, secondCoordinates, thirdCoordinates
            };

            // Given
            CellStatus[,] expectedResult = Ship.BuildShip(board, shipCoordinates);

            // Assert
            for (int row = 0; row < 3; row++)
            {
                Assert.IsTrue(expectedResult[0, row] == board[0, row]);
            }
        }

        [TestMethod]
        public void ShouldCheckIfShipIsDestroyedAndReturnCoordinatesWhenAllCellsAreHit()
        {
            // For
            CellStatus[,] board = new CellStatus[10, 10];

            for (int row = 0; row < 3; row++)
            {
                board[0, row] = CellStatus.Hit;
            }

            int[] firstCoordinates = { 0, 0 };
            int[] secondCoordinates = { 0, 1 };
            int[] thirdCoordinates = { 0, 2 };

            List<int[]> shipCoordinates = new List<int[]>
            {
                firstCoordinates, secondCoordinates, thirdCoordinates
            };

            List<List<int[]>> shipsPositions = new List<List<int[]>>
            {
                shipCoordinates
            };

            // Given
            List<int[]> expectedResult = Ship.CheckIfShipIsDestoyed(board, board, shipsPositions);

            // Assert
            for (int index = 0; index < 3; index++)
            {
                Assert.IsTrue(expectedResult[index] == shipCoordinates[index]);
            }
        }

        [TestMethod]
        public void ShouldCheckIfShipIsDestroyedAndReturnNoneCoordinatesWhenAtLeastOneCellIsNotHit()
        {
            // For
            CellStatus[,] board = new CellStatus[10, 10];

            for (int row = 0; row < 3; row++)
            {
                board[0, row] = CellStatus.Hit;
                if (row == 2)
                {
                    board[0, 2] = CellStatus.Occupied;
                }
            }

            int[] firstCoordinates = { 0, 0 };
            int[] secondCoordinates = { 0, 1 };
            int[] thirdCoordinates = { 0, 2 };

            List<int[]> shipCoordinates = new List<int[]>
            {
                firstCoordinates, secondCoordinates, thirdCoordinates
            };

            List<List<int[]>> shipsPositions = new List<List<int[]>>
            {
                shipCoordinates
            };

            // Given
            List<int[]> expectedResult = Ship.CheckIfShipIsDestoyed(board, board, shipsPositions);

            // Assert
            for (int index = 0; index < 3; index++)
            {
                Assert.IsTrue(expectedResult.Count == 0);
            }
        }
    }
}
