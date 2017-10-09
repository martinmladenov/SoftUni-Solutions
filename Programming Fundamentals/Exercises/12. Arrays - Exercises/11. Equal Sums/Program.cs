namespace _11.Equal_Sums
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for (int middleElementIndex = 0; middleElementIndex < arr.Length; middleElementIndex++)
            {
                int sumLeft = 0;
                for (int leftElementIndex = 0; leftElementIndex < middleElementIndex; leftElementIndex++)
                    sumLeft += arr[leftElementIndex];
                int sumRight = 0;
                for (int rightElementIndex = middleElementIndex + 1;
                    rightElementIndex < arr.Length;
                    rightElementIndex++)
                    sumRight += arr[rightElementIndex];
                if (sumRight != sumLeft) continue;
                Console.WriteLine(middleElementIndex);
                return;
            }
            Console.WriteLine("no");
        }
    }
}
