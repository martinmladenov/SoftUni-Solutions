using System;

namespace _07.Training_Hall_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            double subtotal = 0;
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double price = double.Parse(Console.ReadLine());
                int count = int.Parse(Console.ReadLine());
                Console.WriteLine($"Adding {count} {name}{(count > 1 ? "s" : "")} to cart.");
                subtotal += count * price;
            }
            Console.WriteLine($"Subtotal: ${subtotal:f2}");
            budget -= subtotal;
            Console.WriteLine(budget < 0 ? $"Not enough. We need ${-budget:f2} more." : $"Money left: ${budget:f2}");
        }
    }
}
