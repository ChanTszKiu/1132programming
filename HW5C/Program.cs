using System;

namespace HW5C
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 讀取輸入
            string[] input = Console.ReadLine().Split();
            int a = int.Parse(input[0]);
            int b = int.Parse(input[1]);
            int c = int.Parse(input[2]);

            // 計算判別式 D = b² - 4ac
            int D = b * b - 4 * a * c;

            // 判斷根的種類
            if (D > 0)
                Console.WriteLine("Two different roots");
            else if (D == 0)
                Console.WriteLine("Two same roots");
            else
                Console.WriteLine("No real root");

            Console.ReadKey();
        }
    }
}
