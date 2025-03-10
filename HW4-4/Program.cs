using System;

namespace HW4_4
{
    internal class Program
    {
        // 方法來判斷是否為閏年
        static bool IsLeapYear(int year)
        {
            if (year % 4 == 0)
            {
                if (year % 100 == 0)
                {
                    if (year % 400 == 0)
                    {
                        return true; // 400 的倍數是閏年
                    }
                    return false; // 100 的倍數但不是 400 的倍數是平年
                }
                return true; // 4 的倍數但不是 100 的倍數是閏年
            }
            return false; // 不是 4 的倍數是平年
        }

        static void Main()
        {
            // 讀取輸入
            string[] input = Console.ReadLine().Split();

            if (input.Length != 2 || !int.TryParse(input[0], out int a) || !int.TryParse(input[1], out int b))
            {
                return;
            }

            int start = Math.Min(a, b);
            int end = Math.Max(a, b);
            int leapYearCount = 0;

            // 計算閏年數量
            for (int year = start; year <= end; year++)
            {
                if (IsLeapYear(year))
                {
                    leapYearCount++;
                }
            }

            Console.WriteLine($"Number of leap years between {a} and {b} is {leapYearCount}");

            Console.ReadKey();
        }
    }

}
