namespace _01.Sum_and_Average
{
    using System;
    using System.Linq;

    public class SumAndAverage
    {
        public static void Main()
        {
            var arr = Console.ReadLine()
                             .Split()
                             .Select(int.Parse)
                             .ToArray();

            Console.WriteLine("Sum={0}; Average={1:f2}",
                arr.Sum(), arr.Average());
        }
    }
}
