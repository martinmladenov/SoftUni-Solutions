namespace _14.Factorial_Trail_Zeroes
{
    using System;
    using System.Numerics;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var factorial = Factorial(n);
            int zeroes = GetTrailingZeroesCount(factorial);
            Console.WriteLine(zeroes);
        }

        public static int GetTrailingZeroesCount(BigInteger factorial)
        {
            int count = 0;
            while (factorial % 10 == 0)
            {
                count++;
                factorial /= 10;
            }
            return count;
        }

        public static BigInteger Factorial(int n)
        {
            var factorial = new BigInteger(1);
            for (int i = 2; i <= n; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
    }
}
