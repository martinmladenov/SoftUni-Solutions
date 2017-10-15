namespace _04.Supermarket_Database
{
    using System;
    using System.Collections.Generic;

    public static class SupermarketDatabase
    {
        public static void Main()
        {
            var prices = new Dictionary<string, double>();
            var quantities = new Dictionary<string, int>();
            string input;
            while ((input = Console.ReadLine()) != "stocked")
            {
                var split = input.Split();
                string product = split[0];
                double price = double.Parse(split[1]);
                int quantity = int.Parse(split[2]);
                if (quantities.ContainsKey(product))
                    quantities[product] += quantity;
                else
                    quantities[product] = quantity;
                prices[product] = price;
            }
            double total = 0;
            foreach (var product in prices)
            {
                double price = quantities[product.Key] * product.Value;
                Console.WriteLine($"{product.Key}: ${product.Value:f2} * {quantities[product.Key]} = ${price:f2}");
                total += price;
            }
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Grand Total: ${total:f2}");
        }
    }
}
