namespace HW3C
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 讀取輸入（里程數與停滯時間）
            int distance = int.Parse(Console.ReadLine()); // 以公尺為單位
            int waitTime = int.Parse(Console.ReadLine()); // 以分鐘為單位

            // 計算車資
            int fare = CalculateFare(distance, waitTime);

            // 輸出結果，確保格式正確
            Console.WriteLine($"NT$: {fare}");

            Console.ReadKey();
        }

        /// <summary>
        /// 計算計程車費用
        /// </summary>
        static int CalculateFare(int distance, int waitTime)
        {
            int fare = 85; // 基本費

            // (b) 計算超過 1500 公尺的費用
            if (distance >= 1500)
            {
                fare += 5; // 1500 公尺時加 5 元
                distance -= 1500;

                // 每 250 公尺加 5 元，不足 250 公尺不計費
                fare += (distance / 250) * 5;
            }

            // (c) 計算停滯時間費用
            fare += (waitTime / 2) * 10; // 每 2 分鐘加 10 元，不足 2 分鐘不計費

            return fare;

            
        }

    }
}
