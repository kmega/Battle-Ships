using System;

namespace BattleShips
{
    internal class UI
    {
        private static string PlayerTurn = "";

        internal static void BoardStatus(CellStatus[,] playerOneBoard, int playerNumber)
        {
            if (playerNumber == 1)
            {
                PlayerTurn = "One";
            }
            else
            {
                PlayerTurn = "Two";
            }

            Console.WriteLine("\n Player " + PlayerTurn + ":\n\n     1 2 3 4 5 6 7 8 9 10\n ------------------------");
            for (int i = 0; i < 10; i++)
            {
                switch (i)
                {
                    case 0:
                        Console.Write(" A | ");
                        break;
                    case 1:
                        Console.Write(" B | ");
                        break;
                    case 2:
                        Console.Write(" C | ");
                        break;
                    case 3:
                        Console.Write(" D | ");
                        break;
                    case 4:
                        Console.Write(" E | ");
                        break;
                    case 5:
                        Console.Write(" F | ");
                        break;
                    case 6:
                        Console.Write(" G | ");
                        break;
                    case 7:
                        Console.Write(" H | ");
                        break;
                    case 8:
                        Console.Write(" I | ");
                        break;
                    case 9:
                        Console.Write(" J | ");
                        break;
                }

                for (int j = 0; j < 10; j++)
                {
                    switch (playerOneBoard[i, j])
                    {
                        case CellStatus.Empty:
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write("  ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;
                        case CellStatus.Occupied:
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("  ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;
                        case CellStatus.Blocked:
                            Console.Write("  ");
                            break;
                        case CellStatus.Hit:
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.Write("  ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;
                        case CellStatus.Fired:
                            Console.BackgroundColor = ConsoleColor.DarkMagenta;
                            Console.Write("  ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;
                    }
                }

                switch (i)
                {
                    case 0:
                        Console.Write("\t");
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write("  ");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" - Cell is empty.");
                        break;
                    case 1:
                        Console.Write("\t");
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write("  ");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" - Cell is occupied by a ship.");
                        break;
                    case 2:
                        Console.Write("\t   - Cell is blocked.");
                        break;
                    case 3:
                        Console.Write("\t");
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.Write("  ");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" - Cell was hit.");
                        break;
                    case 4:
                        Console.Write("\t");
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("  ");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write(" - Cell was fired upon.");
                        break;
                }

                Console.Write(Environment.NewLine);
            }
        }
    }
}