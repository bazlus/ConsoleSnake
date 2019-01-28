using System;

namespace SimpleSnake.GameObjects
{
    public class Point
    {
        private int leftX;
        private int topY;

        public Point(int leftX, int topY)
        {
            LeftX = leftX;
            TopY = topY;
        }

        public int TopY
        {
            get { return topY; }
            set
            {
                if (value < -1 || value > Console.WindowHeight)
                {
                    throw new IndexOutOfRangeException();
                }

                this.topY = value;
            }
        }


        public int LeftX
        {
            get { return leftX; }
            set
            {
                if (value < -1 || value > Console.WindowWidth)
                {
                    throw new IndexOutOfRangeException();
                }

                this.leftX = value;
            }
        }

        public void Draw(char symbol)
        {
            Console.SetCursorPosition(LeftX, TopY);
            Console.Write(symbol);
        }

        public void Draw(int leftX, int topY, char symbol)
        {
            Console.SetCursorPosition(leftX, topY);
            Console.Write(symbol);
        }

    }
}
