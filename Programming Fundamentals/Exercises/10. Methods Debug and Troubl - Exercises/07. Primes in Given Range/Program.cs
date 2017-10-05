namespace _07.Primes_in_Given_Range
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            var primes = FindPrimesInRange(start, end);
            Console.WriteLine(string.Join(", ", primes));
        }

        public static List<int> FindPrimesInRange(int start, int end)
        {
            var primes = new List<int>();
            for (int i = start; i <= end; i++)
                if (IsPrime(i))
                    primes.Add(i);
            return primes;
        }

        public static bool IsPrime(long n)
        {
            if (n < 2)
                return false;

            for (int i = 2; i <= Math.Sqrt(n); i++)
                if (n % i == 0)
                    return false;

            return true;
        }
    }
}
