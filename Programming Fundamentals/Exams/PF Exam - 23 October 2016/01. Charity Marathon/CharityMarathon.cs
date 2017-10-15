namespace _01.Charity_Marathon
{
    using System;

    public class CharityMarathon
    {
        public static void Main()
        {
            long days = long.Parse(Console.ReadLine());
            long runners = long.Parse(Console.ReadLine());
            long averageLaps = long.Parse(Console.ReadLine());
            long lapLength = long.Parse(Console.ReadLine());
            long capacity = long.Parse(Console.ReadLine());
            double moneyPerKm = double.Parse(Console.ReadLine());
            double totalMoney = Math.Min(runners, capacity * days) * averageLaps * lapLength / 1000d * moneyPerKm;
            Console.WriteLine($"Money raised: {totalMoney:f2}");
        }
    }
}
