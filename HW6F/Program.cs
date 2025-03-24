using System;

namespace HW6F
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 讀取 M 和 N
            string[] sizes = Console.ReadLine().Split();
            int M = int.Parse(sizes[0]);
            int N = int.Parse(sizes[1]);

            // 讀取 M 個數作為 A 陣列
            string[] inputA = Console.ReadLine().Split();
            int[] A = new int[M];
            for (int i = 0; i < M; i++)
            {
                A[i] = int.Parse(inputA[i]);
            }

            // 讀取 N 個數作為 B 陣列
            string[] inputB = Console.ReadLine().Split();
            int[] B = new int[N];
            for (int i = 0; i < N; i++)
            {
                B[i] = int.Parse(inputB[i]);
            }

            // 進行配對，找出 a + b 可被 7 整除的所有數對
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if ((A[i] + B[j]) % 7 == 0)
                    {
                        Console.Write($"{{{A[i]} {B[j]}}}");
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
