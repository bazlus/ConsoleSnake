using System;
using System.Collections.Generic;
using System.Linq;
using SimpleSnake.GameObjects.Foods;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private const char snakeSymbol = '\u25CF';


        private Queue<Point> snake;
        private Food[] foods;
        private Wall wall;
        private int nextLeftX;
        private int nextTopY;
        private int foodIndex;
        private int foodEaten;
        private int RandomFoodNumber => new Random().Next(0, foods.Length);
        public Snake(Wall wall)
        {
            this.wall = wall;
            snake = new Queue<Point>();
            foods = new Food[3];
            foodIndex = RandomFoodNumber;
            GetFoods();
            CreateSnake();
            this.wall.InitializePlayerStats();

        }



        private void CreateSnake()
        {
            for (int topY = 1; topY <= 6; topY++)
            {
                this.snake.Enqueue(new Point(2, topY));
            }
            this.foods[foodIndex].SetRandomPosition(snake);
        }

        private void GetFoods()
        {
            foods[0] = new FoodHash(this.wall);
            foods[1] = new FoodAsterisk(this.wall);
            foods[2] = new FoodDollar(this.wall);
        }

        public bool IsMoving(Point direction)
        {
            Point snakeHead = snake.Last();

            GetNextPoint(direction, snakeHead);

            bool isPointOfSnake = snake.Any(x => x.LeftX == nextLeftX && x.TopY == nextTopY);

            if (isPointOfSnake)
            {
                return false;
            }

            Point snakeNewHead = new Point(this.nextLeftX, this.nextTopY);

            if (this.wall.IsPointOfWall(snakeNewHead))
            {
                return false;
            }

            this.snake.Enqueue(snakeNewHead);
            snakeNewHead.Draw(snakeSymbol);

            if (foods[foodIndex].IsFoodPoint(snakeNewHead))
            {
                this.Eat(direction, snakeHead);
            }

            Point snakeTail = snake.Dequeue();
            snakeTail.Draw(' ');

            return true;

        }

        private void Eat(Point direction, Point snakeHead)
        {
            int length = foods[foodIndex].FoodPoints;

            for (int i = 0; i < length; i++)
            {
                snake.Enqueue(new Point(this.nextLeftX, this.nextTopY));
                GetNextPoint(direction, snakeHead);
            }

            this.foodEaten++;
            if (foodEaten % 3 == 0)
            {
                this.wall.LevelUp();
            }

            this.wall.AddPoints(foods[foodIndex]);
            this.wall.InitializePlayerStats();

            this.foodIndex = this.RandomFoodNumber;
            this.foods[foodIndex].SetRandomPosition(snake);


        }

        private void GetNextPoint(Point direction, Point snakeHead)
        {
            this.nextLeftX = snakeHead.LeftX + direction.LeftX;
            this.nextTopY = snakeHead.TopY + direction.TopY;
        }
    }
}
