using System;
using SimpleSnake.Core;
using SimpleSnake.GameObjects;

namespace SimpleSnake
{
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            Console.Beep(600, 100);
            ConsoleWindow.CustomizeConsole();
            Wall wall = new Wall(70, 30);
            Snake snake = new Snake(wall);

            Engine engine = new Engine(wall, snake);
            engine.Run();
        }
    }
}
