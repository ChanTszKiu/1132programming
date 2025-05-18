using System;

namespace Program0310
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("請輸入");
            int num = int.Parse(Console.ReadLine());

            switch (num)
            {
                case 0:
                    Console.WriteLine("星期日");
                    break;

                case 1:
                    Console.WriteLine("星期一");
                    break;

                case 2:
                    Console.WriteLine("星期二");
                    break;

                case 3:
                    Console.WriteLine("星期三");
                    break;

                case 4:
                    Console.WriteLine("星期四");
                    break;

                case 5:
                    Console.WriteLine("星期五");
                    break;

                case 6:
                    Console.WriteLine("星期六");
                    break;

            }

            //Console.WriteLine("Hello, World!");

            Console.ReadKey();
        }
    }
}
