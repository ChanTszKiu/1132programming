using System;

namespace HW6E
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 讀取第一行的 N 值
            int N = int.Parse(Console.ReadLine());

            // 讀取第二行的 N 個數字
            string[] inputs = Console.ReadLine().Split();
            int[] numbers = new int[N];
            int[] result = new int[N]; // 用來存符合條件的數字
            int count = 0;

            // 轉換輸入字串為整數陣列
            for (int i = 0; i < N; i++)
            {
                numbers[i] = int.Parse(inputs[i]);
            }

            // 篩選符合條件的數字
            for (int i = 0; i < N; i++)
            {
                if (numbers[i] % 7 == 0 && numbers[i] % 3 != 0)
                {
                    result[count] = numbers[i];
                    count++;
                }
            }

            // 輸出結果
            for (int i = 0; i < count; i++)
            {
                if (i == count - 1)
                    Console.Write($"{result[i]}"); // 最後一個數不加逗號
                else
                    Console.Write($"{result[i]},");
            }
        }
    }
}
