using System;

namespace _05.Weather_Forecast
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();

            try
            {
                sbyte.Parse(number);
                Console.WriteLine("Sunny");
                return;
            }
            catch (Exception)
            {
                // ignored
            }

            try
            {
                int.Parse(number);
                Console.WriteLine("Cloudy");
                return;
            }
            catch (Exception)
            {
                // ignored
            }

            try
            {
                long.Parse(number);
                Console.WriteLine("Windy");
                return;
            }
            catch (Exception)
            {
                // ignored
            }

            try
            {
                decimal.Parse(number);
                Console.WriteLine("Rainy");
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}
