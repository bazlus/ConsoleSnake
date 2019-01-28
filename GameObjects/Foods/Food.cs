using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSnake.GameObjects.Foods
{
    public abstract class Food : Point
    {
        private Wall wall;
        private Random random;
        private char foodSymbol;
        public int FoodPoints { get; private set; }



        protected Food(Wall wall, char foodSymbol, int points)
            :base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            this.foodSymbol = foodSymbol;
            this.FoodPoints = points;
            this.random = new Random();
        }


        public void SetRandomPosition(Queue<Point> snake)
        {

            this.LeftX = random.Next(2, wall.LeftX - 2);
            this.TopY = random.Next(2, wall.TopY - 2);

            bool isOnSnake = snake.Any(x => x.LeftX == LeftX && x.TopY == TopY);

            while (isOnSnake)
            {
                this.LeftX = random.Next(2, wall.LeftX - 2);
                this.TopY = random.Next(2, wall.TopY - 2);

                isOnSnake = snake.Any(x => x.LeftX == LeftX && x.TopY == TopY);
            }

            Console.BackgroundColor = ConsoleColor.Green;
            Draw(foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }

        public bool IsFoodPoint(Point snake)
        {
            return snake.LeftX == this.LeftX &&
                   snake.TopY == this.TopY;
        }
    }
}
