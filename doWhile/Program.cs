using System;

namespace doWhile;

class Program
{
    static void Main(string[] args)
    {
        int sum = 0;
        int i = 1;
        do
        {
            sum += i;
            i++;
        } while (i <= 10);

        //Console.WriteLine("Hello, World!");

        Console.ReadKey();
    }
}
