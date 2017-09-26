using System;

namespace _01.Choose_a_Drink
{
    class Program
    {
        static void Main(string[] args)
        {

            switch (Console.ReadLine())
            {
                case "Athlete":
                    Console.WriteLine("Water");
                    break;
                case "Businessman":
                case "Businesswoman":
                    Console.WriteLine("Coffee");
                    break;
                case "SoftUni Student":
                    Console.WriteLine("Beer");
                    break;
                default:
                    Console.WriteLine("Tea");
                    break;
            }

        }
    }
}
