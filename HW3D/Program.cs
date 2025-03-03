namespace HW3D
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            // 嘗試將輸入轉換為整數
            if (int.TryParse(input, out int year) && year > 0)
            {
                // 計算年份與生肖的對應
                int zodiacIndex = (year - 85) % 12;

                // 使用 if-else 判斷對應的生肖
                if (zodiacIndex == 0)
                    Console.WriteLine($"{year}: Rat");
                else if (zodiacIndex == 1)
                    Console.WriteLine($"{year}: Ox");
                else if (zodiacIndex == 2)
                    Console.WriteLine($"{year}: Tiger");
                else if (zodiacIndex == 3)
                    Console.WriteLine($"{year}: Hare");
                else if (zodiacIndex == 4)
                    Console.WriteLine($"{year}: Dragon");
                else if (zodiacIndex == 5)
                    Console.WriteLine($"{year}: Snake");
                else if (zodiacIndex == 6)
                    Console.WriteLine($"{year}: Horse");
                else if (zodiacIndex == 7)
                    Console.WriteLine($"{year}: Sheep");
                else if (zodiacIndex == 8)
                    Console.WriteLine($"{year}: Monkey");
                else if (zodiacIndex == 9)
                    Console.WriteLine($"{year}: Rooster");
                else if (zodiacIndex == 10)
                    Console.WriteLine($"{year}: Dog");
                else if (zodiacIndex == 11)
                    Console.WriteLine($"{year}: Boar");
            }
            else
            {
                // 輸入不是正整數時的錯誤訊息
                Console.WriteLine($"{input}: Wrong Input");
            }

            Console.ReadKey();
        }
    }
}
