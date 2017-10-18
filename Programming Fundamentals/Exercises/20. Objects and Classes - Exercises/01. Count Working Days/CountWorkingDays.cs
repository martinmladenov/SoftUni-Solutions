namespace _01.Count_Working_Days
{
    using System;
    using System.Globalization;
    using System.Linq;

    public class CountWorkingDays
    {
        public static void Main()
        {
            var holidays =
                new[]
                {
                    new DateTime(1,1,1),
                    new DateTime(1,3,3),
                    new DateTime(1,5,1),
                    new DateTime(1,5,6),
                    new DateTime(1,5,24),
                    new DateTime(1,9,6),
                    new DateTime(1,9,22),
                    new DateTime(1,11,1),
                    new DateTime(1,12,24),
                    new DateTime(1,12,25),
                    new DateTime(1,12,26)
                };
            var startDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var endDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture).AddDays(1);
            int count = 0;
            for (var currDate = startDate;
                currDate.Date != endDate.Date ||
                   currDate.Month != endDate.Month ||
                   currDate.Year != endDate.Year;
                   currDate = currDate.AddDays(1))
            {
                if (currDate.DayOfWeek != DayOfWeek.Saturday &&
                    currDate.DayOfWeek != DayOfWeek.Sunday &&
                    !holidays.Any(h => h.Day == currDate.Day &&
                                       h.Month == currDate.Month))
                    count++;
            }
            Console.WriteLine(count);
        }
    }
}
