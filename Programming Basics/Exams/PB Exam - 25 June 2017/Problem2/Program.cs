using System;

namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            double currentRecord = double.Parse(Console.ReadLine());
            double distanceInMeters = double.Parse(Console.ReadLine());
            double secondsPerMeter = double.Parse(Console.ReadLine());

            double timeInSeconds = distanceInMeters * secondsPerMeter;
            timeInSeconds += Math.Floor(distanceInMeters / 15) * 12.5;

            Console.WriteLine(currentRecord > timeInSeconds
                ? $"Yes, he succeeded! The new world record is {timeInSeconds:f2} seconds."
                : $"No, he failed! He was {timeInSeconds - currentRecord:f2} seconds slower.");
        }
    }
}
