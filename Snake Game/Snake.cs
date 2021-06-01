using System;
using System.Collections.Generic;
using System.Text;

namespace Snake_Game
{
    class Snake
    {
        /// <summary>
        /// X and Y coordinates of the Snake object.
        /// </summary>
        public Coordinates SnakeCoordinates = new Coordinates();
        public Direction LastDirection { get; protected set; }

        public List<Coordinates> LastCoordinates { get; set; }

        private ConsoleKeyInfo KeyPressed;

        public int SnakeLength { get; set; }

        public Snake()
        {
            LastCoordinates = new List<Coordinates>();
            LastDirection = Direction.Left;
            SnakeLength = 0;
            SnakeCoordinates.X = 50;
            SnakeCoordinates.Y = 10;
        }

        public void UpdatePosition()
        {
            if (SnakeLength > 0)
            {
                UpdateBody();
            }

            if (Console.KeyAvailable)
            {
                KeyPressed = Console.ReadKey(true);
                switch (KeyPressed.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (LastDirection == Direction.Right) // checks to make sure player does not go into opposite direction of where he currently is
                        {
                            break;
                        }
                        LastDirection = Direction.Left;
                        break;
                    case ConsoleKey.UpArrow:
                        if (LastDirection == Direction.Bottom) // checks to make sure player does not go into opposite direction of where he currently is
                        {
                            break;
                        }
                        LastDirection = Direction.Top;
                        break;
                    case ConsoleKey.RightArrow:
                        if (LastDirection == Direction.Left) // checks to make sure player does not go into opposite direction of where he currently is
                        {
                            break;
                        }
                        LastDirection = Direction.Right;
                        break;
                    case ConsoleKey.DownArrow:
                        if (LastDirection == Direction.Bottom) // checks to make sure player does not go into opposite direction of where he currently is
                        {
                            break;
                        }
                        LastDirection = Direction.Bottom;
                        break;
                }
            }

            switch (LastDirection)
            {
                case Direction.Top:
                    SnakeCoordinates.Y -= 1;
                    break;
                case Direction.Right:
                    SnakeCoordinates.X += 1;
                    break;
                case Direction.Left:
                    SnakeCoordinates.X -= 1;
                    break;
                case Direction.Bottom:
                    SnakeCoordinates.Y += 1;
                    break;
            }
        }

        public void AddLength()
        {
            SnakeLength += 1;
            LastCoordinates.Add(new Coordinates());
            UpdateBody();
        }

        public void UpdateBody()
        {
            for (int i = SnakeLength-1; i > 0 ; i--)
            {
                LastCoordinates[i] = LastCoordinates[i-1];
            }
            LastCoordinates[0] = SnakeCoordinates;
        }
    }

    enum Direction
    {
        Top,
        Right,
        Left,
        Bottom
    }
}
