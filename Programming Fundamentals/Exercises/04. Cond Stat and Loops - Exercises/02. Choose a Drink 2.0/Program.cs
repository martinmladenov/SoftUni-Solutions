using System;

namespace _02.Choose_a_Drink_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            double price;
            string profession = Console.ReadLine();
            switch (profession)
            {
                case "Athlete":
                    price = 0.7;
                    break;
                case "Businessman":
                case "Businesswoman":
                    price = 1;
                    break;
                case "SoftUni Student":
                    price = 1.7;
                    break;
                default:
                    price = 1.2;
                    break;
            }
            Console.WriteLine($"The {profession} has to pay {price* int.Parse(Console.ReadLine()):f2}.");
        }
    }
}
