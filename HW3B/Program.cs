using System;

namespace HW3B
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 讀取輸入並解析為三個整數
            string[] input = Console.ReadLine().Split();

            // 確保輸入為三個數字
            if (input.Length != 3 || !int.TryParse(input[0], out int a) || !int.TryParse(input[1], out int b) || !int.TryParse(input[2], out int c))
            {
                Console.WriteLine("No");
                return;
            }

            // 將三個邊長排序（確保 c 為最長邊）
            int[] sides = { a, b, c };
            Array.Sort(sides);
            a = sides[0];
            b = sides[1];
            c = sides[2];

            // 判斷是否為銳角三角形
            if (a * a + b * b > c * c)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}