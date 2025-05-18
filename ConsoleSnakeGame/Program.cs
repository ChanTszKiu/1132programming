using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ConsoleSnakeGame
{
    class Program
    {
        static int width = 40;
        static int height = 20;
        static List<Position> snake = new List<Position>();
        static Position food;
        static Direction direction = Direction.Right;
        static Random rand = new Random();
        static bool gameOver = false;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Init();
            int speed = 100;
            bool paused = false;

            while (!gameOver)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;

                    if (key == ConsoleKey.P)
                        paused = !paused;
                    else if (!paused)
                        ChangeDirection(key);
                }

                if (!paused)
                {
                    Move(ref speed);
                    Draw();
                }

                Thread.Sleep(speed);
            }

            Console.SetCursorPosition(0, height + 2);
            Console.WriteLine("Game Over! Press any key to exit...");
            Console.ReadKey();
        }

        static void Init()
        {
            snake.Clear();
            snake.Add(new Position(10, 10));
            snake.Add(new Position(9, 10));
            snake.Add(new Position(8, 10));
            direction = Direction.Right;
            GenerateFood();
        }

        static void Draw()
        {
            Console.Clear();

            // Draw border
            for (int i = 0; i <= width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("#");
                Console.SetCursorPosition(i, height);
                Console.Write("#");
            }
            for (int i = 0; i <= height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("#");
                Console.SetCursorPosition(width, i);
                Console.Write("#");
            }

            // Draw food
            Console.SetCursorPosition(food.X, food.Y);
            Console.Write("O");

            // Draw snake
            foreach (var pos in snake)
            {
                Console.SetCursorPosition(pos.X, pos.Y);
                Console.Write("*");
            }

            // Show score
            Console.SetCursorPosition(0, height + 1);
            Console.Write($"Score: {snake.Count - 3}");
        }

        static void Move(ref int speed)
        {
            Position head = snake[0];
            Position newHead = new Position(head.X, head.Y);

            switch (direction)
            {
                case Direction.Up: newHead.Y--; break;
                case Direction.Down: newHead.Y++; break;
                case Direction.Left: newHead.X--; break;
                case Direction.Right: newHead.X++; break;
            }

            if (newHead.X == 0 || newHead.X == width || newHead.Y == 0 || newHead.Y == height || snake.Contains(newHead))
            {
                gameOver = true;
                return;
            }

            snake.Insert(0, newHead);

            if (newHead.X == food.X && newHead.Y == food.Y)
            {
                GenerateFood();

                // 每吃到5個食物加速一次（最小到40ms）
                int level = snake.Count - 3;
                if (level % 5 == 0 && speed > 40)
                    speed -= 10;
            }
            else
            {
                snake.RemoveAt(snake.Count - 1);
            }
        }

        static void ChangeDirection(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (direction != Direction.Down) direction = Direction.Up;
                    break;
                case ConsoleKey.DownArrow:
                    if (direction != Direction.Up) direction = Direction.Down;
                    break;
                case ConsoleKey.LeftArrow:
                    if (direction != Direction.Right) direction = Direction.Left;
                    break;
                case ConsoleKey.RightArrow:
                    if (direction != Direction.Left) direction = Direction.Right;
                    break;
            }
        }

        static void GenerateFood()
        {
            Position newFood;
            do
            {
                newFood = new Position(rand.Next(1, width - 1), rand.Next(1, height - 1));
            } while (snake.Contains(newFood));

            food = newFood;
        }

        enum Direction { Up, Down, Left, Right }

        struct Position
        {
            public int X;
            public int Y;

            public Position(int x, int y)
            {
                X = x;
                Y = y;
            }

            public override bool Equals(object obj)
            {
                if (!(obj is Position)) return false;
                var p = (Position)obj;
                return p.X == X && p.Y == Y;
            }

            public override int GetHashCode()
            {
                return X * 397 ^ Y;
            }
        }
    }
}
