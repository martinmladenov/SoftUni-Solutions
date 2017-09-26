using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02___Styrofoam
{
    class Program
    {
        static void Main(string[] args)
        {

            double budget = double.Parse(Console.ReadLine());
            double houseArea = double.Parse(Console.ReadLine());
            int windows = int.Parse(Console.ReadLine());
            double sqMPerPack = double.Parse(Console.ReadLine());
            double packPrice = double.Parse(Console.ReadLine());

            double neededSqM = (houseArea - windows * 2.4) * 1.1;
            double neededPacks = Math.Ceiling(neededSqM / sqMPerPack);
            double totalPrice = neededPacks * packPrice;

            if (budget >= totalPrice)
            {
                Console.WriteLine($"Spent: {totalPrice:f2}");
                Console.WriteLine($"Left: {budget-totalPrice:f2}");
            }
            else
                Console.WriteLine($"Need more: {totalPrice-budget:f2}");

        }
    }
}
