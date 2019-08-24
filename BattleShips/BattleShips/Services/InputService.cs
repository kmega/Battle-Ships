using System;
using System.Linq;

namespace BattleShips
{
    internal class InputService
    {
        internal string GetPlayerInput()
        {
            // Get player input and then return it.
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

            switch (char.ToLower(playerInput[0]))
            {
                case 'a':
                    newInput[0] = 0;
                    break;
                case 'b':
                    newInput[0] = 1;
                    break;
                case 'c':
                    newInput[0] = 2;
                    break;
                case 'd':
                    newInput[0] = 3;
                    break;
                case 'e':
                    newInput[0] = 4;
                    break;
                case 'f':
                    newInput[0] = 5;
                    break;
                case 'g':
                    newInput[0] = 6;
                    break;
                case 'h':
                    newInput[0] = 7;
                    break;
                case 'i':
                    newInput[0] = 8;
                    break;
                case 'j':
                    newInput[0] = 9;
                    break;
            }

            newInput[1] = Convert.ToInt32(new String(playerInput.Where(Char.IsDigit).ToArray())) - 1;

            switch (playerInput.Substring(playerInput.Length - 4).ToLower())
            {
                case "up":
                    newInput[2] = 1;
                    break;
                case "down":
                    newInput[2] = 2;
                    break;
                case "left":
                    newInput[2] = 3;
                    break;
                case "right":
                    newInput[2] = 4;
                    break;
            }

            return newInput;
        }
    }
}