using System;

namespace _02.Vapor_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            double balance = double.Parse(Console.ReadLine());
            double initialBalance = balance;
            string input;
            while ((input = Console.ReadLine()) != "Game Time")
            {
                double price;
                switch (input)
                {
                    case "OutFall 4":
                        price = 39.99;
                        break;
                    case "CS: OG":
                        price = 15.99;
                        break;
                    case "Zplinter Zell":
                        price = 19.99;
                        break;
                    case "Honored 2":
                        price = 59.99;
                        break;
                    case "RoverWatch":
                        price = 29.99;
                        break;
                    case "RoverWatch Origins Edition":
                        price = 39.99;
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        continue;
                }
                if (balance < price)
                {
                    Console.WriteLine("Too Expensive");
                    continue;
                }
                    balance -= price;
                Console.WriteLine($"Bought {input}");
                if (balance != 0) continue;
                Console.WriteLine("Out of money!");
                return;
            }
            Console.WriteLine($"Total spent: ${initialBalance - balance:f2}. Remaining: ${balance:f2}");
        }
    }
}
