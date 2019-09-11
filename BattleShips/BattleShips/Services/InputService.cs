using System;
using System.Linq;

namespace BattleShips
{
    internal class InputService
    {
        internal string GetPlayerInput()
        {
            // Return player input.
            return Console.ReadLine();
        }

        internal void CheckPlayerInput(string playerInput, ref Player player)
        {
            // Convert string coordinates to array based coordinates.
            int[] convertedInput = ConvertPlayerInput(playerInput);

            // Check if ship is in board boundaries and if it's nearby any other ships.
            CheckingService checkingService = new CheckingService();

            if (checkingService.CheckBoardBoundaries(convertedInput, ref player) == true && checkingService.CheckNearbyCells(convertedInput, ref player) == true)
            {
                BoardService boardService = new BoardService();

                boardService.PlaceShipOnBoard(convertedInput, ref player);
            }
            else
            {
                Console.Write("Something went wrong:\n" +
                    "- Did you use wrong coordinates?\n" +
                    "- Did you placed your ship outside the board boundaries?\n" +
                    "- Did you placed your ship near another already placed ship?\n\n");
            }
        }

        internal int[] ConvertPlayerInput(string playerInput)
        {
            // Convert input to three numbers representing { A-J, 1-10, Direction }.
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

            try
            {
                switch (playerInput = new String(playerInput.Where(Char.IsLetter).ToArray()).Substring(1).ToLower())
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
            }
            catch
            {
                // NOTE: I'm RE-using this method for shooting (it does NOT require direction). Try-catch is here intentionally to avoid exepction.
            }

            return newInput;
        }
    }
}