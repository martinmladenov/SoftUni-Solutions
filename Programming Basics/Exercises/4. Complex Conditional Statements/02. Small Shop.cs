using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            var product = Console.ReadLine();
            var town = Console.ReadLine();
            var amount = double.Parse(Console.ReadLine());

            double price = 0;

            if(town == "Sofia")
            {
                if (product == "coffee")
                    price = 0.5;
                else if (product == "water")
                    price = 0.8;
                else if (product == "beer")
                    price = 1.2;
                else if (product == "sweets")
                    price = 1.45;
                else if (product == "peanuts")
                    price = 1.6;
            }
            else if (town == "Plovdiv")
            {
                if (product == "coffee")
                    price = 0.4;
                else if (product == "water")
                    price = 0.7;
                else if (product == "beer")
                    price = 1.15;
                else if (product == "sweets")
                    price = 1.3;
                else if (product == "peanuts")
                    price = 1.5;
            }
            else if (town == "Varna")
            {
                if (product == "coffee")
                    price = 0.45;
                else if (product == "water")
                    price = 0.7;
                else if (product == "beer")
                    price = 1.1;
                else if (product == "sweets")
                    price = 1.35;
                else if (product == "peanuts")
                    price = 1.55;
            }

            Console.WriteLine(amount * price);

        }
    }
}