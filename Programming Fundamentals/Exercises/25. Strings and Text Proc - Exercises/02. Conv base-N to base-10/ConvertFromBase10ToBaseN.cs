namespace _02.Conv_base_N_to_base_10
{
    using System;
    using System.Numerics;

    public class ConvertFromBase10ToBaseN
    {
        public static void Main()
        {
            var split = Console.ReadLine().Split();
            string n = split[1];
            int b = int.Parse(split[0]);
            var result = new BigInteger(0);
            for (int i = 0; i < n.Length; i++)
            {
                int c = n[n.Length - 1 - i] - '0';
                result += c * BigInteger.Pow(b, i);
            }
            Console.WriteLine(result);
        }
    }
}
