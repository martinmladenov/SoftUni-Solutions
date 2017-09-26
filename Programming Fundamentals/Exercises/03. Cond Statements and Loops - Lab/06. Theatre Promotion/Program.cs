using System;

namespace _06._Theatre_Promotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfDay = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            if (typeOfDay == "Weekday")
            {
                if (age < 0 || age > 122)
                    Console.WriteLine("Error!");
                else if (0 <= age && age <= 18)
                    Console.WriteLine("12$");
                else if(age <= 64)
                    Console.WriteLine("18$");
                else
                    Console.WriteLine("12$");
            }
            else if (typeOfDay == "Weekend")
            {
                if(age < 0 || age > 122)
                    Console.WriteLine("Error!");
                else if (0 <= age && age <= 18)
                    Console.WriteLine("15$");
                else if (age <= 64)
                    Console.WriteLine("20$");
                else
                    Console.WriteLine("15$");
            }
            else if (typeOfDay == "Holiday")
            {
                if (age < 0 || age > 122)
                    Console.WriteLine("Error!");
                else if (0 <= age && age <= 18)
                    Console.WriteLine("5$");
                else if (age <= 64)
                    Console.WriteLine("12$");
                else
                    Console.WriteLine("10$");
            }
            else
                Console.WriteLine("Error!");
        }
    }
}
