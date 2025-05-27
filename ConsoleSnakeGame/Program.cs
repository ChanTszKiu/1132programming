using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleSnakeGame
{
    class Program
    {
        // 遊戲場地大小
        static int width = 40;
        static int height = 20;

        // 蛇的身體與遊戲控制變數
        static List<Position> snake = new List<Position>();
        static Position food;
        static Direction direction = Direction.Right;
        static Random rand = new Random();
        static bool gameOver = false;
        static bool gameStarted = false;
        static int speed = 100;
        static int level = 1;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Init();
            Draw(); // 一開始先畫出提示畫面

            bool paused = false;

            while (!gameOver)
            {
                // 有鍵盤輸入時處理
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;

                    // 還沒開始：只要按方向鍵或 WASD 就開始
                    if (!gameStarted && IsMovementKey(key))
                    {
                        gameStarted = true;
                        ChangeDirection(key); // 第一下輸入也轉向
                        Console.Clear();
                        Console.SetCursorPosition(0, height + 2);
                        Console.WriteLine($"遊戲開始，目前速度 Lv.{level}");
                        Thread.Sleep(1000);
                    }

                    if (gameStarted)
                    {
                        if (key == ConsoleKey.P)
                            paused = !paused;
                        else if (!paused)
                            ChangeDirection(key);
                    }
                }

                // 遊戲啟動且沒暫停時執行移動與繪製
                if (gameStarted && !paused)
                {
                    Move(ref speed);
                    Draw();
                }

                Thread.Sleep(speed);
            }

            Console.SetCursorPosition(0, height + 4);
            Console.WriteLine("Game Over! Press any key to exit...");
            Console.ReadKey();
        }

        // 遊戲初始化
        static void Init()
        {
            snake.Clear();
            snake.Add(new Position(10, 10));
            snake.Add(new Position(9, 10));
            snake.Add(new Position(8, 10));
            direction = Direction.Right;
            GenerateFood();
        }

        // 畫出整個畫面
        static void Draw()
        {
            Console.Clear();

            // 畫邊框
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

            // 畫食物
            Console.SetCursorPosition(food.X, food.Y);
            Console.Write("O");

            // 畫蛇
            foreach (var pos in snake)
            {
                Console.SetCursorPosition(pos.X, pos.Y);
                Console.Write("*");
            }

            // 分數與提示文字
            Console.SetCursorPosition(0, height + 1);
            Console.Write($"Score: {snake.Count - 3}");

            Console.SetCursorPosition(0, height + 2);
            Console.Write("按下 P 可暫停 / 繼續遊戲");

            if (!gameStarted)
            {
                Console.SetCursorPosition(0, height + 3);
                Console.Write("請按 方向鍵 或 W A S D 鍵開始遊戲...");
            }
        }

        // 控制移動與邏輯
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

            // 撞牆或自撞
            if (newHead.X == 0 || newHead.X == width || newHead.Y == 0 || newHead.Y == height || snake.Contains(newHead))
            {
                gameOver = true;
                return;
            }

            snake.Insert(0, newHead);

            // 吃到食物
            if (newHead.X == food.X && newHead.Y == food.Y)
            {
                GenerateFood();
                int score = snake.Count - 3;

                // 每 5 分升級一次速度
                if (score / 5 + 1 > level)
                {
                    level = score / 5 + 1;
                    if (speed > 40) speed -= 10;

                    Console.SetCursorPosition(0, height + 3);
                    Console.WriteLine($"分數達標！速度上升一級！現在速度為 Lv.{level}");
                    Thread.Sleep(1000);
                }
            }
            else
            {
                // 沒吃到則移除尾巴
                snake.RemoveAt(snake.Count - 1);
            }
        }

        // 處理方向轉向（含方向鍵與 WASD）
        static void ChangeDirection(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    if (direction != Direction.Down) direction = Direction.Up;
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    if (direction != Direction.Up) direction = Direction.Down;
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    if (direction != Direction.Right) direction = Direction.Left;
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    if (direction != Direction.Left) direction = Direction.Right;
                    break;
            }
        }

        // 判斷是否為方向控制鍵
        static bool IsMovementKey(ConsoleKey key)
        {
            return key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow ||
                   key == ConsoleKey.LeftArrow || key == ConsoleKey.RightArrow ||
                   key == ConsoleKey.W || key == ConsoleKey.A ||
                   key == ConsoleKey.S || key == ConsoleKey.D;
        }

        // 隨機產生新食物
        static void GenerateFood()
        {
            Position newFood;
            do
            {
                newFood = new Position(rand.Next(1, width - 1), rand.Next(1, height - 1));
            } while (snake.Contains(newFood));

            food = newFood;
        }

        // 方向列舉
        enum Direction { Up, Down, Left, Right }

        // 座標資料結構
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
