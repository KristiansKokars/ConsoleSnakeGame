using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Snake_Game
{
    static class GameLogic
    {
        static Screen MainScreen { get; set; }
        static Snake MainSnake { get; set; }
        static Food MainFood { get; set; }

        static int Score { get; set; }

        public const int SCREEN_HEIGHT = 60;
        public const int SCREEN_WIDTH = 32;
        public static void SetupGame()
        {
            // Set Basic Window Settings
            Console.SetWindowSize(SCREEN_HEIGHT, SCREEN_WIDTH);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.CursorVisible = false;

            // Setup objects
            MainScreen = new Screen();
            MainSnake = new Snake();
            MainFood = new Food();
            Score = 0;
        }

        public static void PlayGame()
        {
            // TODO - vertical movement feels too fast compared to horizontal, remake arena or deal with that feel

            // Print Area
            MainScreen.ScreenArea[MainFood.FoodCoordinates.Y, MainFood.FoodCoordinates.X] = 'F';
            while (true)
            {
                // Redrawing the screen and updating position
                Console.SetCursorPosition(0, 0);
                MainScreen.ScreenArea[MainSnake.SnakeCoordinates.Y, MainSnake.SnakeCoordinates.X] = ' '; // Deletes the previous position
                for (int i = 0; i < MainSnake.SnakeLength; i++)
                {
                    MainScreen.ScreenArea[MainSnake.LastCoordinates[i].Y, MainSnake.LastCoordinates[i].X] = ' ';
                }
                MainSnake.UpdatePosition(); // updates snake position

                // Check if Position is legal (AKA not game over position)

                // Checking if Snek go out of boundaries
                if (MainSnake.SnakeCoordinates.X < 1 || MainSnake.SnakeCoordinates.X > SCREEN_HEIGHT-2 || MainSnake.SnakeCoordinates.Y < 1 || MainSnake.SnakeCoordinates.Y > SCREEN_WIDTH-4)
                {
                    break;
                }

                // Check if snek got food
                if (MainSnake.SnakeCoordinates == MainFood.FoodCoordinates)
                {
                    Score += 1;
                    MainSnake.AddLength();
                    MainFood.Respawn(MainSnake);
                    MainScreen.ScreenArea[MainFood.FoodCoordinates.Y, MainFood.FoodCoordinates.X] = 'F';
                }

                // Check for collision, using else if since if we get apple, we shouldn't check for collision with body on same frame
                else if (MainSnake.LastCoordinates.Find(x => x == MainSnake.SnakeCoordinates) != default)
                {
                    break;
                }

                // Redraw the Screen with new position
                for (int i = 0; i < MainSnake.SnakeLength; i++)
                {
                    MainScreen.ScreenArea[MainSnake.LastCoordinates[i].Y, MainSnake.LastCoordinates[i].X] = 'o';
                }

                MainScreen.ScreenArea[MainSnake.SnakeCoordinates.Y, MainSnake.SnakeCoordinates.X] = '0'; // Draws the snake in the screen
                
                MainScreen.RedrawScreen(); // Redraws the whole screen

                Console.SetCursorPosition(0, 30);
                //Console.WriteLine("SCORE: {0} || Snek Position {1};{2} || Food Coordinates {3};{4}", 
                //    Score, 
                //    MainSnake.SnakeCoordinates.X, MainSnake.SnakeCoordinates.Y,
                //    MainFood.FoodCoordinates.X, MainFood.FoodCoordinates.Y);
                Console.WriteLine("SCORE: {0}", Score);
                Thread.Sleep(80);
            }
            Console.SetCursorPosition(0, 31);
            Console.WriteLine($"YOU LOST\nSCORE: {Score}");
        }
    }
}
