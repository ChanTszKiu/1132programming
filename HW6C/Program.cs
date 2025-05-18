using System;

namespace HW6C
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] voteCounts = new int[8]; // 陣列存放 8 個景點的票數

            string[] inputs = Console.ReadLine().Split(' ');

            // 計算各景點的得票數
            for (int i = 0; i < inputs.Length; i++)
            {
                if (int.TryParse(inputs[i], out int vote)) // 確保輸入是數字
                {
                    if (vote == -1) // -1 表示輸入結束
                        break;

                    if (vote >= 1 && vote <= 8) // 判斷是否為有效票數
                        voteCounts[vote - 1]++; // 記錄該景點的票數
                }
            }

            // 找出前三名的景點（索引即景點號碼 -1）
            int first = 0, second = 0, third = 0;
            int firstIndex = -1, secondIndex = -1, thirdIndex = -1;

            for (int i = 0; i < 8; i++)
            {
                if (voteCounts[i] > first)
                {
                    third = second; thirdIndex = secondIndex;
                    second = first; secondIndex = firstIndex;
                    first = voteCounts[i]; firstIndex = i;
                }
                else if (voteCounts[i] > second)
                {
                    third = second; thirdIndex = secondIndex;
                    second = voteCounts[i]; secondIndex = i;
                }
                else if (voteCounts[i] > third)
                {
                    third = voteCounts[i]; thirdIndex = i;
                }
            }

            // 輸出前三名的景點
            Console.WriteLine($"Hotspot#{firstIndex + 1}: {first}");
            Console.WriteLine($"Hotspot#{secondIndex + 1}: {second}");
            Console.WriteLine($"Hotspot#{thirdIndex + 1}: {third}");
        }
    }
}
