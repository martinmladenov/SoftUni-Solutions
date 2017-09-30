using System;

namespace _11.Convert_Speed_Units
{
    class Program
    {
        static void Main(string[] args)
        {
            int meters = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int seconds = int.Parse(Console.ReadLine());

            int totalTimeInSeconds = 3600 * hours + 60 * minutes + seconds;
            float mps = (float)meters / totalTimeInSeconds;

            float totalTimeInHours = (float)totalTimeInSeconds / 3600;
            float kilometers = (float)meters / 1000;
            float kmh = kilometers / totalTimeInHours;

            float miles = (float)meters / 1609;
            float mph = miles / totalTimeInHours;

            Console.WriteLine(mps);
            Console.WriteLine(kmh);
            Console.WriteLine(mph);

        }
    }
}
