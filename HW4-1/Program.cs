using System;

namespace HW4_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            if (input.Length != 2 || !int.TryParse(input[0], out int x) || !int.TryParse(input[1], out int y) || x <= 0 || y <= 0)
            {
                Console.WriteLine("請輸入有效的正整數。");
                return;
            }

            int min = Math.Min(x, y);
            int max = Math.Max(x, y);
            int sum = 0;

            for (int i = min; i <= max; i++)
            {
                if (i % 2 == 0)
                {
                    sum += i;
                }
            }

            Console.WriteLine($"{sum}");
        }
    }
}
