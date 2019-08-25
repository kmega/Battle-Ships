namespace BattleShips
{
    internal class BoardService
    {
        internal Cell[,] CreateNewEmptyBoard()
        {
            // Create an array of 10x10, fill it with empty cells and then return it.
            Cell[,] newBoard = new Cell[10, 10];

            for (int i = 0; i < newBoard.GetLength(0); i++)
            {
                for (int j = 0; j < newBoard.GetLength(1); j++)
                {
                    newBoard[i, j] = Cell.Empty;
                }
            }

            return newBoard;
        }
    }
}