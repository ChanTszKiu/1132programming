using System;

namespace PerfecctNumApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 1; i < N; i++)
            {
                if (N % i == 0)
                {
                    sum += i;
                }
            }

            if (sum == N)
            {
                Console.WriteLine($"{N}: perfect number");
            }
            else
            {
                Console.WriteLine($"{N}: normal number");
            }
            //Console.WriteLine("Hello, World!");
        }
    }
}
