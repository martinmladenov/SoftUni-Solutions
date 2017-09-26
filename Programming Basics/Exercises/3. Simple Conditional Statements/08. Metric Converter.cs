using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            double input = double.Parse(Console.ReadLine());

            string from = Console.ReadLine();
            string to = Console.ReadLine();

            double meter = 0;

            if (from == "mm")
                meter = input / 1000;
            else if (from == "cm")
                meter = input / 100;
            else if (from == "mi")
                meter = input / 0.000621371192;
            else if (from == "in")
                meter = input / 39.3700787;
            else if (from == "km")
                meter = input / 0.001;
            else if (from == "ft")
                meter = input / 3.2808399;
            else if (from == "yd")
                meter = input / 1.0936133;
            else
                meter = input;

            double output = 0;

            if (to == "mm")
                output = meter * 1000;
            else if (to == "cm")
                output = meter * 100;
            else if (to == "mi")
                output = meter * 0.000621371192;
            else if (to == "in")
                output = meter * 39.3700787;
            else if (to == "km")
                output = meter * 0.001;
            else if (to == "ft")
                output = meter * 3.2808399;
            else if (to == "yd")
                output = meter * 1.0936133;
            else
                output = meter;

            Console.WriteLine($"{output:f8}");

        }
    }
}
