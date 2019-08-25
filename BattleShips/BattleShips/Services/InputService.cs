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

        internal void CheckPlayerInput(string playerInput, ref Player player)
        {
            int[] convertedInput = ConvertPlayerInput(playerInput);

            CheckingService checkingService = new CheckingService();

            if (checkingService.CheckBoardBoundaries(convertedInput, ref player) == true && checkingService.CheckNearbyCells(convertedInput, ref player) == true)
            {
                ShipService shipService = new ShipService();

                shipService.PlaceShipOnBoard(convertedInput, ref player);
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

            char[] digits = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            switch (playerInput.TrimStart(digits).ToLower())
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