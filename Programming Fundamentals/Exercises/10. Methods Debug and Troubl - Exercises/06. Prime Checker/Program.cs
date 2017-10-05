namespace _06.Prime_Checker
{
    using System;

    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(IsPrime(long.Parse(Console.ReadLine())));
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
