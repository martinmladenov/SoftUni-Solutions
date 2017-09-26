using System;

namespace Problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string size = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());

            double price = -1;
            if (size == "small")
            {
                if (fruit == "Watermelon")
                    price = 56;
                else if (fruit == "Mango")
                    price = 36.66;
                else if (fruit == "Pineapple")
                    price = 42.1;
                else if (fruit == "Raspberry")
                    price = 20;
                price *= 2;
            }
            else if (size == "big")
            {
                if (fruit == "Watermelon")
                    price = 28.7;
                else if (fruit == "Mango")
                    price = 19.6;
                else if (fruit == "Pineapple")
                    price = 24.8;
                else if (fruit == "Raspberry")
                    price = 15.2;
                price *= 5;
            }

            price *= count;
            if (price > 1000)
                price *= 0.5;
            else if (price >= 400)
                price *= 0.85;
            Console.WriteLine($"{price:f2} lv.");

        }
    }
}
