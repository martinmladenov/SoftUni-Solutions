using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double amount = double.Parse(Console.ReadLine());

            double price = -1;

            if(day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
            {
                if (fruit == "banana") price = 2.5;
                else if (fruit == "apple") price = 1.2;
                else if (fruit == "orange") price = 0.85;
                else if (fruit == "grapefruit") price = 1.45;
                else if (fruit == "kiwi") price = 2.7;
                else if (fruit == "pineapple") price = 5.5;
                else if (fruit == "grapes") price = 3.85;
            }
            else if(day == "Saturday" || day == "Sunday")
            {
                if (fruit == "banana") price = 2.7;
                else if (fruit == "apple") price = 1.25;
                else if (fruit == "orange") price = 0.9;
                else if (fruit == "grapefruit") price = 1.6;
                else if (fruit == "kiwi") price = 3;
                else if (fruit == "pineapple") price = 5.6;
                else if (fruit == "grapes") price = 4.2;
            }

            if(price == -1)
                Console.WriteLine("error");
            else
                Console.WriteLine("{0:f2}", amount * price);

        }
    }
}