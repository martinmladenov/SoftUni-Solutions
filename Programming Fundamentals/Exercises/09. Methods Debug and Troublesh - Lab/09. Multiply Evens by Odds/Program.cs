using System;

namespace _09.Multiply_Evens_by_Odds
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(GetMultipleOfEvensAndOdds(int.Parse(Console.ReadLine())));
        }

        private static int GetMultipleOfEvensAndOdds(int n)
        {
            n = Math.Abs(n);
            int sumEvens = GetSumOfEvens(n);
            int sumOdds = GetSumOfOdds(n);
            return sumEvens * sumOdds;
        }

        private static int GetSumOfEvens(int n)
        {
            int sum = 0;
            while (n > 0)
            {
                int lastDigit = n % 10;
                if (lastDigit % 2 == 0)
                    sum += lastDigit;
                n /= 10;
            }

            return sum;
        }

        private static int GetSumOfOdds(int n)
        {
            int sum = 0;
            while (n > 0)
            {
                int lastDigit = n % 10;
                if (lastDigit % 2 != 0)
                    sum += lastDigit;
                n /= 10;
            }

            return sum;
        }
    }
}