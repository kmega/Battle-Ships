using System;

namespace BattleShips
{
    internal class CheckInput
    {
        internal int[] UserCoordinates(string userInput)
        {
            int[] coordinates = { -1, -1 };

            try
            {
                userInput = userInput.ToLower();

                string value1 = userInput[0].ToString();
                string value2 = userInput[1].ToString();

                try
                {
                    coordinates[0] = Convert.ToInt32(value1) - 1;
                    coordinates[1] = ChangeLetterToDecimal(value2);

                    return coordinates;
                }
                catch
                {
                    try
                    {
                        coordinates[0] = ChangeLetterToDecimal(value1);
                        coordinates[1] = Convert.ToInt32(value2) - 1;

                        return coordinates;
                    }
                    catch
                    {
                        return coordinates;
                    }
                }
            }
            catch
            {
                return coordinates;
            }
        }

        private int ChangeLetterToDecimal(string letter)
        {
            switch (letter)
            {
                case "a":
                    return 0;
                case "b":
                    return 1;
                case "c":
                    return 2;
                case "d":
                    return 3;
                case "e":
                    return 4;
                case "f":
                    return 5;
                case "g":
                    return 6;
                case "h":
                    return 7;
                case "i":
                    return 8;
                case "j":
                    return 9;
                default:
                    return -1;
            }
        }

        internal string UserDirection(string userInput)
        {
            return null;
        }
    }
}