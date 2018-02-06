namespace _04._Add_VAT
{
    using System;
    using System.Linq;

    public class AddVat
    {
        public static void Main()
        {
            double[] prices = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            foreach (var price in prices.Select(p => p * 1.2))
            {
                Console.WriteLine($"{price:f2}");
            }
        }
    }
}
