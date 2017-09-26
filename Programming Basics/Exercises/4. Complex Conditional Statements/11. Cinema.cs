using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            string type = Console.ReadLine();
            int r = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            double price = -1;

            if (type == "Premiere") price = 12;
            else if (type == "Normal") price = 7.5;
            else if (type == "Discount") price = 5;

            double total = r * c * price;
            Console.WriteLine("{0:f2} leva", total);

        }
    }
}