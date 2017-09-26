using System;

namespace _03.Restaurant_Discount
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            string package = Console.ReadLine();

            string hallType;
            double price;
            if (people <= 50)
            {
                hallType = "Small Hall";
                price = 2500;
            }
            else if (people <= 100)
            {
                hallType = "Terrace";
                price = 5000;
            }
            else if (people <= 120)
            {
                hallType = "Great Hall";
                price = 7500;
            }
            else
            {
                Console.WriteLine("We do not have an appropriate hall.");
                return;
            }

            double discount = 1;
            switch (package)
            {
                case "Platinum":
                    price += 1000;
                    discount = 0.15;
                    break;
                case "Gold":
                    price += 750;
                    discount = 0.10;
                    break;
                case "Normal":
                    price += 500;
                    discount = 0.05;
                    break;
            }
            price *= 1 - discount;
            Console.WriteLine($"We can offer you the {hallType}{Environment.NewLine}The price per person is {price/people:f2}$");
        }
    }
}
