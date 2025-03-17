using System;

namespace HW5B
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 讀取點的座標
            string[] input = Console.ReadLine().Split();
            int x = int.Parse(input[0]);
            int y = int.Parse(input[1]);

            // 計算距離 d(O, A)
            double distance = Math.Sqrt(x * x + y * y);

            // 輸出格式
            Console.WriteLine($"O(0, 0)");
            Console.WriteLine($"A({x}, {y})");
            Console.WriteLine($"d(O, A) = {distance:F2}");

            // 判斷是否在圓內
            if (distance <= 100)
                Console.WriteLine("inside");
            else
                Console.WriteLine("outside");

            Console.ReadKey();
        }
    }
}
