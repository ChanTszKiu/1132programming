using System;

namespace HW5A
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 讀取兩點座標
            string[] input1 = Console.ReadLine().Split();
            string[] input2 = Console.ReadLine().Split();

            // 解析整數
            int x1 = int.Parse(input1[0]);
            int y1 = int.Parse(input1[1]);
            int x2 = int.Parse(input2[0]);
            int y2 = int.Parse(input2[1]);

            // 計算距離
            double distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

            // 輸出格式
            Console.WriteLine($"A({x1}, {y1})");
            Console.WriteLine($"B({x2}, {y2})");
            Console.WriteLine($"d(A, B) = {distance:F2}");

            Console.ReadKey();
        }
    }
}
