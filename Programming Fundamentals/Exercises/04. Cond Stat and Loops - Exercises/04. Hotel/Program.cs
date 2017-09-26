using System;

namespace _04.Hotel
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            double studioPrice;
            double doublePrice;
            double suitePrice;

            if (month == "May" || month == "October")
            {
                studioPrice = 50;
                doublePrice = 65;
                suitePrice = 75;
                if (nights > 7)
                    studioPrice *= 0.95;
            }
            else if (month == "June" || month == "September")
            {
                studioPrice = 60;
                doublePrice = 72;
                suitePrice = 82;
                if (nights > 14)
                    doublePrice *= 0.9;
            }
            else if (month == "July" || month == "August" || month == "December")
            {
                studioPrice = 68;
                doublePrice = 77;
                suitePrice = 89;
                if (nights > 14)
                    suitePrice *= 0.85;
            }
            else
                return;

            studioPrice *= nights - (nights > 7 && (month == "September" || month == "October") ? 1 : 0);
            doublePrice *= nights;
            suitePrice *= nights;

            Console.WriteLine($"Studio: {studioPrice:f2} lv.");
            Console.WriteLine($"Double: {doublePrice:f2} lv.");
            Console.WriteLine($"Suite: {suitePrice:f2} lv.");
        }
    }
}
