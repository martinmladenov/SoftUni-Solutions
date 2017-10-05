namespace _13.Factorial
{
    using System;
    using System.Numerics;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Factorial(n).ToString());
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
