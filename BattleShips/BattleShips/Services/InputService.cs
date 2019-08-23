using System;

namespace BattleShips
{
    internal class InputService
    {
        internal string GetPlayerInput()
        {
            return Console.ReadLine();
        }

        internal void CheckPlayerInput(string playerInput, ref Cell[,] playerBoard)
        {
            int[] convertedInput = ConvertPlayerInput(playerInput);

            CheckingService checkingService = new CheckingService();

            if (checkingService.CheckBoardBoundaries(playerInput, ref playerBoard) == true && checkingService.CheckNearbyCells(playerInput, ref playerBoard) == true)
            {
                BoardService boardService = new BoardService();

                boardService.PlaceShip(playerInput, ref playerBoard);
            }
            else
            {
                Console.Write("Wrong coordinates, ships nearby and blah blah :V");
            }
        }

        private int[] ConvertPlayerInput(string playerInput)
        {
            int[] newInput = { 0, 0, 0 };

            switch (playerInput[0])
            {
                case 'a':
                case 'A':
                    newInput[0] = 0;
                    break;
                case 'b':
                case 'B':
                    newInput[0] = 1;
                    break;
                case 'c':
                case 'C':
                    newInput[0] = 2;
                    break;
                case 'd':
                case 'D':
                    newInput[0] = 3;
                    break;
                case 'e':
                case 'E':
                    newInput[0] = 4;
                    break;
                case 'f':
                case 'F':
                    newInput[0] = 5;
                    break;
                case 'g':
                case 'G':
                    newInput[0] = 6;
                    break;
                case 'h':
                case 'H':
                    newInput[0] = 7;
                    break;
                case 'i':
                case 'I':
                    newInput[0] = 8;
                    break;
                case 'j':
                case 'J':
                    newInput[0] = 9;
                    break;
            }

            return newInput;
        }
    }
}