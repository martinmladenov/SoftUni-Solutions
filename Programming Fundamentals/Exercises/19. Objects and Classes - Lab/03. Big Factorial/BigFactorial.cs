namespace _03.Big_Factorial
{
    using System;
    using System.Numerics;

    public class BigFactorial
    {
        public static void Main()
        {
            var bi = new BigInteger(1);
            int n = int.Parse(Console.ReadLine());
            for (int i = 2; i <= n; i++)
                bi *= i;
            Console.WriteLine(bi.ToString());
        }
    }
}
