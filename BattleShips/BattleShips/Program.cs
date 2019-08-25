using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BattleShipsUnitTest")]

namespace BattleShips
{
    class Program
    {
        static void Main()
        {
            // Create GameEngine() and Start() the game.
            GameEngine gameEngine = new GameEngine();
            gameEngine.Start();
        }
    }
}
