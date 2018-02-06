namespace _09._List_Of_Predicates
{
    using System;
    using System.Linq;

    public class ListOfPredicates
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] divisors = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Func<int, int, bool> isDivisible = (i, d) => i % d == 0;

            for (int i = 1; i <= n; i++)
            {
                bool divisible = true;

                foreach (var divisor in divisors)
                {
                    if (!isDivisible(i, divisor))
                    {
                        divisible = false;
                        break;
                    }
                }

                if (divisible)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
