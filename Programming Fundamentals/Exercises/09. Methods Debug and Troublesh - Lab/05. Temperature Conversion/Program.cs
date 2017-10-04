using System;

namespace _05.Temperature_Conversion
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine($"{FahrenheitToCelsius(double.Parse(Console.ReadLine())):f2}");
        }

        private static double FahrenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }
    }
}