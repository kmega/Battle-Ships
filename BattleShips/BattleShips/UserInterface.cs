using System;

namespace BattleShips
{
    internal class UserInterface
    {
        internal void ShowBoard(Cell[,] board)
        {
            // Write a letter, row of cells and then make a new line for next iteration.
            for (int i = 0; i < board.GetLength(0); i++)
            {
                WriteLetter(i);

                WriteOneRowOfCells(board, i);

                Console.WriteLine();
            }
        }

        private void WriteLetter(int i)
        {
            // Change background color to black and then write the letter.
            Console.BackgroundColor = ConsoleColor.Black;

            switch (i)
            {
                case 0:
                    Console.Write(" A ");
                    break;
                case 1:
                    Console.Write(" B ");
                    break;
                case 2:
                    Console.Write(" C ");
                    break;
                case 3:
                    Console.Write(" D ");
                    break;
                case 4:
                    Console.Write(" E ");
                    break;
                case 5:
                    Console.Write(" F ");
                    break;
                case 6:
                    Console.Write(" G ");
                    break;
                case 7:
                    Console.Write(" H ");
                    break;
                case 8:
                    Console.Write(" I ");
                    break;
                case 9:
                    Console.Write(" J ");
                    break;
            }

            Console.Write("| ");
        }

        private void WriteOneRowOfCells(Cell[,] board, int i)
        {
            // Translate Cell Enums to user friendly squares with colors.
            for (int j = 0; j < board.GetLength(1); j++)
            {
                switch (board[i, j])
                {
                    case Cell.Empty:
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write("  ");
                        break;
                    case Cell.Occupied:
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write("  ");
                        break;
                    case Cell.Hit:
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("  ");
                        break;
                    case Cell.Damaged:
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.Write("  ");
                        break;
                    case Cell.Blocked:
                        Console.Write("  ");
                        break;
                }
            }
        }
    }
}