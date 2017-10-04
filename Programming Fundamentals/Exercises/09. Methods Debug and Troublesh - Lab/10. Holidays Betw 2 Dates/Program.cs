using System;
using System.Globalization;

namespace _10.Holidays_Betw_2_Dates
{
    internal class HolidaysBetweenTwoDates
    {
        private static void Main()
        {
            var startDate = DateTime.ParseExact(Console.ReadLine(),
                "d.M.yyyy", CultureInfo.InvariantCulture);
            var endDate = DateTime.ParseExact(Console.ReadLine(),
                "d.M.yyyy", CultureInfo.InvariantCulture);
            var holidaysCount = 0;
            for (var date = startDate; date <= endDate; date = date.AddDays(1))
                if (date.DayOfWeek == DayOfWeek.Saturday ||
                    date.DayOfWeek == DayOfWeek.Sunday)
                    holidaysCount++;
            Console.WriteLine(holidaysCount);
        }
    }
}