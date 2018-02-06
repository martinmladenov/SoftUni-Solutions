namespace _04._Find_Evens_or_Odds
{
    using System;
    using System.Linq;

    public class FindEvensOrOdds
    {
        public static void Main()
        {
            int[] bounds = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string evenOrOdd = Console.ReadLine();

            Predicate<int> predicate = null;
            if (evenOrOdd == "even")
            {
                predicate = i => i % 2 == 0;
            }
            else if (evenOrOdd == "odd")
            {
                predicate = i => i % 2 != 0;
            }

            for (int i = bounds[0]; i <= bounds[1]; i++)
            {
                if (predicate(i))
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
