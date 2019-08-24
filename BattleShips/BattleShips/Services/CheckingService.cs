namespace BattleShips
{
    internal class CheckingService
    {
        internal bool CheckBoardBoundaries(int[] playerInput, ref Player player)
        {
            int index = player.shipIndex;

            for (int i = 0; i < player.ships[index].length; i++)
            {
                try
                {
                    switch (playerInput[2])
                    {
                        case 1:
                            player.ships[index].coordinates.Add(new int[] { playerInput[0] - i, playerInput[1] });
                            break;
                        case 2:
                            player.ships[index].coordinates.Add(new int[] { playerInput[0] + i, playerInput[1] });
                            break;
                        case 3:
                            player.ships[index].coordinates.Add(new int[] { playerInput[0], playerInput[1] - i });
                            break;
                        case 4:
                            player.ships[index].coordinates.Add(new int[] { playerInput[0], playerInput[1] + i });
                            break;
                    }
                }
                catch
                {
                    return false;
                }
            }

            return true;
        }

        internal bool CheckNearbyCells(int[] playerInput, ref Player player)
        {
            int index = player.shipIndex;

            foreach (var coordinates in player.ships[index].coordinates)
            {
                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        try
                        {
                            if (player.board[coordinates[0] + i, coordinates[1] + j] == Cell.Occupied)
                            {
                                return false;
                            }
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }
            }

            return true;
        }
    }
}