using System;

namespace HW6A
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split(' ');

            int[] votes = new int[inputs.Length]; // 用陣列存放輸入數據
            int count = 0; // 記錄有效票數的數量

            // 迴圈處理每個輸入值
            for (int i = 0; i < inputs.Length; i++)
            {
                if (int.TryParse(inputs[i], out int vote)) // 確保輸入是數字
                {
                    if (vote >= 1 && vote <= 8) // 判斷是否為有效範圍
                    {
                        votes[count] = vote; // 存入陣列
                        count++; // 計數 +1
                    }
                }
            }

            Console.WriteLine($"The number of valid votes is: {count}");

            Console.ReadKey();
        }
    }
}
