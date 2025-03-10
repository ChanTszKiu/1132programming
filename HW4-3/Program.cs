using System;

namespace HW4_3
{
    internal class Program
    {
        // 方法來計算 GCD
        static int FindGCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        static void Main()
        {
            string[] input = Console.ReadLine().Split();

            if (input.Length != 2 || !int.TryParse(input[0], out int x) || !int.TryParse(input[1], out int y))
            {
                return;
            }

            int gcd = FindGCD(x, y);
            int lcm = (x * y) / gcd; // LCM 計算公式

            Console.WriteLine($"The GCD of ({x}, {y}) is: {gcd}");
            Console.WriteLine($"The LCM of ({x}, {y}) is: {lcm}");

            Console.ReadKey();
        }
    }
}
