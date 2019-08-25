namespace BattleShips
{
    internal class CheckingService
    {
        internal bool CheckBoardBoundaries(int[] playerInput, ref Player player)
        {
            Ship ship = player.ships[player.shipIndex];

            for (int i = 0; i < ship.length; i++)
            {
                try
                {
                    switch (playerInput[2])
                    {
                        case 1:
                            ship.coordinates.Add(new int[] { playerInput[0] - i, playerInput[1] });
                            break;
                        case 2:
                            ship.coordinates.Add(new int[] { playerInput[0] + i, playerInput[1] });
                            break;
                        case 3:
                            ship.coordinates.Add(new int[] { playerInput[0], playerInput[1] - i });
                            break;
                        case 4:
                            ship.coordinates.Add(new int[] { playerInput[0], playerInput[1] + i });
                            break;
                    }
                }
                catch
                {
                    ship.coordinates.Clear();

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