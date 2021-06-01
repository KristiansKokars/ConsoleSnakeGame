using System;
using System.Threading;

namespace Snake_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            GameLogic.SetupGame();
            Console.WriteLine("#####################SNAKE CONSOLE GAME#####################\n" +
                "                        HOW TO PLAY\n" +
                "                 Use arrow keys to move.\n" +
                "         Navigate the snake (0) zero to the Food (F).\n" +
                " Be careful to not collide into the walls or your body! (o)\n" +
                "                    Press Enter to play!");
            Console.Read();
            GameLogic.PlayGame();
        }
    }
}
