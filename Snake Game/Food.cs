using System;
using System.Collections.Generic;
using System.Text;

namespace Snake_Game
{
    class Food
    {
        /// <summary>
        /// X and Y coordinates of the Food object.
        /// </summary>
        public Coordinates FoodCoordinates = new Coordinates();

        private Random RandomizeRespawn = new Random();

        /// <summary>
        /// Initializes Food with the preset X, Y coordinates of 10;3.
        /// </summary>
        public Food()
        {
            FoodCoordinates.X = 10;
            FoodCoordinates.Y = 3;
        }

        /// <summary>
        /// Respawns the Food object in a random spot on screen.
        /// </summary>
        public void Respawn(Snake snake)
        {
            // TODO - make it respawn away from snek guaranteed and not in the same spot
            while (snake.LastCoordinates.Find(x => x == FoodCoordinates) != default)
            {
                FoodCoordinates.X = RandomizeRespawn.Next(1, GameLogic.SCREEN_HEIGHT - 1);
                FoodCoordinates.Y = RandomizeRespawn.Next(1, GameLogic.SCREEN_WIDTH - 4);
            }
            
        }
    }
}
