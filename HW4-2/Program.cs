using System;
using System.Linq;

namespace HW4_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                return;
            }

            int[] scores = Console.ReadLine().Split().Select(s => int.TryParse(s, out int num) ? num : -1).ToArray();

            if (scores.Length != n || scores.Any(s => s < 0))
            {
                return;
            }

            int max = scores.Max();
            int min = scores.Min();
            double avg = scores.Average();
            double passRate = (scores.Count(s => s >= 60) / (double)n) * 100;

            Console.WriteLine($"Max: {max}, Min: {min}, AVG: {avg:F2}");
            Console.WriteLine($"Pass rate: {passRate:F1}%");

            Console.ReadKey();
        }
    }
}
