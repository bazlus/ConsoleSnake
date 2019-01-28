using System;
using SimpleSnake.GameObjects.Foods;

namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        private PlayerStats playerStats;
        public Wall(int leftX, int topY)
            :base(leftX, topY)
        {
            SetHorizontalLine(0);
            SetHorizontalLine(this.TopY);
            this.playerStats = new PlayerStats();
            SetVerticalLine(0);
            SetVerticalLine(this.LeftX - 1);
        }
        private const char wallSymbol = '\u25A0';
        private void SetHorizontalLine(int topY)
        {
            for (int i = 0; i < this.LeftX; i++)
            {
                Draw(i, topY, wallSymbol);
            }
        }

        private void SetVerticalLine(int leftX)
        {
            for (int i = 0; i < this.TopY; i++)
            {
                Draw(leftX, i, wallSymbol);
            }
        }

        public bool IsPointOfWall(Point snake)
        {
            return snake.TopY == 0 || snake.LeftX == 0 ||
                   snake.LeftX == this.LeftX - 1 || snake.TopY == this.TopY;
        }

        public void InitializePlayerStats()
        {
            Console.SetCursorPosition(LeftX + 3, 0);
            Console.Write($"Player points: {this.playerStats.PlayerPoints}");
            Console.SetCursorPosition(LeftX + 3, 1);
            Console.Write($"Level: {this.playerStats.PlayerLevel}");
        }

        public void AddPoints(Food food)
        {
            this.playerStats.PlayerPoints += (ulong) food.FoodPoints * 12;
        }

        public void LevelUp()
        {
            this.playerStats.LevelUp();
        }
    }
}
