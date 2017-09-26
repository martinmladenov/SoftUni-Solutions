using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03___Truck_Driver
{
    class Program
    {
        static void Main(string[] args)
        {
            int months = int.Parse(Console.ReadLine());

            double electricity = 0;
            double water = months * 20;
            double internet = months * 15;

            for (int i = 0; i < months; i++)
                electricity += double.Parse(Console.ReadLine());

            double other = (electricity + water + internet) * 1.2;
            double ave = (electricity + water + internet + other) / months;
            Console.WriteLine($"Electricity: {electricity:f2} lv");
            Console.WriteLine($"Water: {water:f2} lv");
            Console.WriteLine($"Internet: {internet:f2} lv");
            Console.WriteLine($"Other: {other:f2} lv");
            Console.WriteLine($"Average: {ave:f2} lv");
        }
    }
}
