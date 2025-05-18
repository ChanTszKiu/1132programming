using System;

namespace _6D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            int[] divisibleBy7 = new int[N / 7]; // 預估最多存 N/7 個數
            int count = 0;

            // 找出 1 ~ N 之間可被 7 整除的數
            for (int i = 1; i <= N; i++)
            {
                if (i % 7 == 0)
                {
                    divisibleBy7[count] = i; // 存入陣列
                    count++;
                }
            }

            // 輸出結果（使用雙迴圈來處理輸出格式）
            for (int i = 0; i < count; i++)
            {
                if (i == count - 1)
                    Console.Write($"{divisibleBy7[i]}"); // 最後一個數字不加逗號
                else
                    Console.Write($"{divisibleBy7[i]},");
            }

            Console.ReadKey();
        }
    }
}
