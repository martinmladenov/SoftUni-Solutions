namespace _01.Anonymous_Downsite
{
    using System;
    using System.Numerics;

    public class AnonymousDownsite
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int securityKey = int.Parse(Console.ReadLine());
            decimal totalLoss = 0;
            var token = new BigInteger(1);
            for (int i = 0; i < n; i++)
            {
                var split = Console.ReadLine().Split();
                Console.WriteLine(split[0]);
                totalLoss += decimal.Parse(split[2]) * long.Parse(split[1]);
                token *= securityKey;
            }
            Console.WriteLine($"Total Loss: {totalLoss:f20}");
            Console.WriteLine($"Security Token: {token.ToString()}");
        }
    }
}
