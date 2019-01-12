﻿using System;

namespace BattleShips
{
    internal class UI
    {
        internal void BoardStatus(CellStatus[,] board)
        {
            Console.WriteLine("- 1 2 3 4 5 6 7 8 9 10");
            for (int i = 0; i < 10; i++)
            {
                switch (i)
                {
                    case 0:
                        Console.Write("A ");
                        break;
                    case 1:
                        Console.Write("B ");
                        break;
                    case 2:
                        Console.Write("C ");
                        break;
                    case 3:
                        Console.Write("D ");
                        break;
                    case 4:
                        Console.Write("E ");
                        break;
                    case 5:
                        Console.Write("F ");
                        break;
                    case 6:
                        Console.Write("G ");
                        break;
                    case 7:
                        Console.Write("H ");
                        break;
                    case 8:
                        Console.Write("I ");
                        break;
                    case 9:
                        Console.Write("J ");
                        break;
                }
                for (int j = 0; j < 10; j++)
                {
                    switch (board[i, j])
                    {
                        case CellStatus.Empty:
                            Console.Write("  ");
                            break;
                        case CellStatus.Occupied:
                            Console.Write("O ");
                            break;
                        case CellStatus.Hit:
                            Console.Write("H ");
                            break;
                        case CellStatus.Blocked:
                            Console.Write("B ");
                            break;
                    }
                }
                Console.Write(Environment.NewLine);
            }
        }
    }
}