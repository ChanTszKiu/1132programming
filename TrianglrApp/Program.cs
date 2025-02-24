using System;

namespace TrianglrApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

            string[] inputs = Console.ReadLine().Split();
            int a = int.Parse(inputs[0]);
            int b = int.Parse(inputs[1]);
            int c = int.Parse(inputs[2]);

            {
                // 判斷是否滿足三角形不等式定理
                if (a + b > c && a + c > b && b + c > a)
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No");
                }
            }

            Console.ReadKey();
        }
    }
}
