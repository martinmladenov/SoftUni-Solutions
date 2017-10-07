namespace _01.Day_of_Week
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string[] days = {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };
            int number = int.Parse(Console.ReadLine()) - 1;
            if (number >= 0 && number < 7)
                Console.WriteLine(days[number]);
            else
                Console.WriteLine("Invalid Day!");
        }
    }
}
