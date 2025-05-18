using System;

namespace HW5D
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

            if (D > 0)
            {
                // 計算兩個根
                double x1 = (-b + Math.Sqrt(D)) / (2.0 * a);
                double x2 = (-b - Math.Sqrt(D)) / (2.0 * a);

                // 確保 x1 > x2
                if (x1 < x2)
                {
                    double temp = x1;
                    x1 = x2;
                    x2 = temp;
                }

                Console.WriteLine($"Two different roots x1 = {x1:F2}, x2 = {x2:F2}");
            }
            else if (D == 0)
            {
                // 重根
                double x = -b / (2.0 * a);
                Console.WriteLine($"Two same roots x = {x:F2}");
            }
            else
            {
                // 無實根
                Console.WriteLine("No real root");
            }

            Console.ReadKey();
        }
    }
}
