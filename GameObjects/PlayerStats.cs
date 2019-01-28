using SimpleSnake.GameObjects.Foods;
using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleSnake.GameObjects
{
    public class PlayerStats
    {
        private ulong playerPoints;
        private long playerLevel;

        public ulong PlayerPoints
        {
            get => this.playerPoints;
            set { this.playerPoints = value; }
        }

        public long PlayerLevel
        {
            get => this.playerLevel;
            set { this.playerLevel = value; }
        }
        public PlayerStats()
        {
            this.playerPoints = 0;
            this.playerLevel = 0;
        }


        public void IncreasePoints(Food foodType)
        {
            playerPoints += (ulong) foodType.FoodPoints;
        }

        public void LevelUp()
        {
            this.playerLevel++;
        }
    }
}
