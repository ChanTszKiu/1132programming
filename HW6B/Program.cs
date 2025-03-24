using System;

namespace HW6B
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] voteCounts = new int[8]; // 陣列索引對應景點 1~8 (索引 0 對應景點 1)

            string[] inputs = Console.ReadLine().Split(' ');

            // 迴圈處理每個輸入值
            for (int i = 0; i < inputs.Length; i++)
            {
                if (int.TryParse(inputs[i], out int vote)) // 確保輸入是數字
                {
                    if (vote == -1) // -1 表示輸入結束
                    {
                        break;
                    }
                    else if (vote >= 1 && vote <= 8) // 判斷是否為有效票數
                    {
                        voteCounts[vote - 1]++; // 記錄該景點的票數 (索引 = 景點號碼 -1)
                    }
                }
            }

            // 輸出每個景點的得票數
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine($"Hotspot#{i + 1}: {voteCounts[i]}");
            }

        }
    }
}
