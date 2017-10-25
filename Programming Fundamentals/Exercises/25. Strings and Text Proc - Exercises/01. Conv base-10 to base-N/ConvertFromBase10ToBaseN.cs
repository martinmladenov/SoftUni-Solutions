namespace _01.Conv_base_10_to_base_N
{
    using System;
    using System.Numerics;

    public class ConvertFromBase10ToBaseN
    {
        public static void Main()
        {
            var split = Console.ReadLine().Split();
            var n = BigInteger.Parse(split[1]);
            int b = int.Parse(split[0]);
            string baseN = "";
            while (n > 0)
            {
                baseN = n % b + baseN;
                n /= b;
            }
            Console.WriteLine(baseN);
        }
    }
}
