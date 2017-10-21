namespace _3.Equal_Sums
{
    using System.IO;
    using System.Linq;

    public class EqualSums
    {
        public static void Main()
        {
            var arr = File.ReadAllText("input.txt").Split(' ').Select(int.Parse).ToArray();
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
                File.WriteAllText("output.txt", middleElementIndex.ToString());
                return;
            }
            File.WriteAllText("output.txt", "no");
        }
    }
}
