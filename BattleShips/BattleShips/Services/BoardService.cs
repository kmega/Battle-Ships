namespace BattleShips
{
    internal class BoardService
    {
        internal CellStatus[,] CreateNewEmptyBoard()
        {
            CellStatus[,] newBoard = new CellStatus[10, 10];

            for (int i = 0; i < newBoard.GetLength(0); i++)
            {
                for (int j = 0; j < newBoard.GetLength(1); j++)
                {
                    newBoard[i, j] = CellStatus.Empty;
                }
            }

            return newBoard;
        }
    }
}