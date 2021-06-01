using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake_Game
{
    class Screen
    {
        /// <summary>
        /// The screen area that is drawn and manipulated.
        /// </summary>
        public char[,] ScreenArea = new char[GameLogic.SCREEN_WIDTH-2, GameLogic.SCREEN_HEIGHT];

        public Screen()
        {
            Initialize();
        }

        public void Initialize()
        {
            // Make a arena box
            for (int column = 0; column < GameLogic.SCREEN_HEIGHT; column++) // first row top line
            {
                ScreenArea[0, column] = '#';
            }

            for (int row = 1; row < GameLogic.SCREEN_WIDTH-3; row++) // top and bottom rows are filled so we have 28 rows to fill
            {
                ScreenArea[row, 0] = '#';
                for (int column = 1; column < GameLogic.SCREEN_HEIGHT; column++)
                {
                    ScreenArea[row, column] = ' ';
                }
                ScreenArea[row, GameLogic.SCREEN_HEIGHT-1] = '#';
            }

            for (int i = 0; i < GameLogic.SCREEN_HEIGHT; i++) //last row bottom line
            {
                ScreenArea[GameLogic.SCREEN_WIDTH-3, i] = '#';
            }
        }

        public void RedrawScreen()
        {
            // Draws the screen
            for (int i = 0; i < ScreenArea.GetLength(0); i++)
            {
                for (int j = 0; j < ScreenArea.GetLength(1); j++)
                {
                    if (ScreenArea[i, j] == 'F') // to color the Food Red
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(ScreenArea[i, j]);
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        continue;
                    }
                    if (ScreenArea[i, j] == '0') // to color the Snake Green
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write(ScreenArea[i, j]);
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        continue;
                    }
                    if (ScreenArea[i, j] == 'o') // to color the Snake Green
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(ScreenArea[i, j]);
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        continue;
                    }
                    Console.Write(ScreenArea[i, j]);
                }
                Console.WriteLine();
            }
        }

    }
    public struct Coordinates
    {
        public int X { get; set; }
        public int Y { get; set; }

        public static bool operator ==(Coordinates first, Coordinates second)
        {
            if (first.X == second.X && first.Y == second.Y)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Coordinates first, Coordinates second)
        {
            if (first.X != second.X || first.Y != second.Y)
            {
                return true;
            }
            return false;
        }
    }
}
