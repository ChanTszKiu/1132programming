using System;

using System.CodeDom.Compiler;

namespace _0303App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*int h = 175;
            int w = 62;
            double bmi = w / ((h / 100.0) * (h / 100.0));
            Console.WriteLine("Height:{0}cm, Weight:{1}kg, BMI:{2}", h, w, bmi);
            //Console.WriteLine("Hello, World!");
            Console.ReadKey();*/
            string name = Console.ReadLine();  // 讀取姓名
            double weight = double.Parse(Console.ReadLine());  // 讀取體重
            int height = int.Parse(Console.ReadLine());  // 讀取身高

            // 輸出格式
            Console.WriteLine("====================");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"W: {weight:F1}kg, H: {height}cm");
            Console.WriteLine("====================");

            Console.ReadKey();
        }
    }
}
