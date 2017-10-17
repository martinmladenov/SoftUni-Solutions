namespace _07.Sales_Report
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SalesReport
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var sales = new SortedDictionary<string, List<Sale>>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string town = input.Split()[0];
                if (!sales.ContainsKey(town))
                    sales[town] = new List<Sale>();
                sales[town].Add(new Sale(input));
            }
            foreach (var sale in sales)
            {
                Console.WriteLine($"{sale.Key} -> {sale.Value.Sum(s => s.GetTotal()):f2}");
            }
        }
    }

    public class Sale
    {
        public string Product { get; }
        public double Price { get; }
        public double Quantity { get; }

        public Sale(string input)
        {
            var split = input.Split();
            Product = split[1];
            Price = double.Parse(split[2]);
            Quantity = double.Parse(split[3]);
        }

        public double GetTotal()
        {
            return Price * Quantity;
        }
    }
}
