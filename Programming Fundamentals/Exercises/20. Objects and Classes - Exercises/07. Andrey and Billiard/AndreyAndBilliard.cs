namespace _07.Andrey_and_Billiard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AndreyAndBilliard
    {
        public static void Main()
        {
            var prices = new Dictionary<string, double>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var split = Console.ReadLine().Split('-');
                prices[split[0]] = double.Parse(split[1]);
            }
            var customers = new List<Customer>();
            string input;
            while ((input = Console.ReadLine()) != "end of clients")
            {
                var split = input.Split(',', '-');
                if (!prices.ContainsKey(split[1]))
                    continue;
                var customer = customers
                    .FirstOrDefault(c => c.Name == split[0]);
                if (customer == null)
                {
                    customer = new Customer(split[0]);
                    customers.Add(customer);
                }
                if (customer.Purchases.ContainsKey(split[1]))
                    customer.Purchases[split[1]] += int.Parse(split[2]);
                else
                    customer.Purchases[split[1]] = int.Parse(split[2]);
            }
            double total = 0;
            foreach (var customer in customers
                .OrderBy(c => c.Name))
            {
                Console.WriteLine(customer.Name);
                foreach (var purchase in customer.Purchases)
                {
                    Console.WriteLine($"-- {purchase.Key} - {purchase.Value}");
                }
                double bill = customer.GetBill(prices);
                total += bill;
                Console.WriteLine($"Bill: {bill:f2}");
            }
            Console.WriteLine($"Total bill: {total:f2}");
        }
    }

    public class Customer
    {
        public string Name;
        public Dictionary<string, int> Purchases;

        public Customer(string name)
        {
            Name = name;
            Purchases = new Dictionary<string, int>();
        }

        public double GetBill(Dictionary<string, double> prices)
        {
            return Purchases.Sum(kvp => prices[kvp.Key] * kvp.Value);
        }
    }
}
