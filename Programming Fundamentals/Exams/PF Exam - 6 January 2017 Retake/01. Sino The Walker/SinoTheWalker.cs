namespace _01.Sino_The_Walker
{
    using System;
    using System.Linq;

    public class SinoTheWalker
    {
        public static void Main()
        {
            var leaveTime = Console.ReadLine()
                .Split(':')
                .Select(long.Parse)
                .Select((i, index) => i * (long)Math.Pow(60, 2 - index))
                .Sum();
            long steps = long.Parse(Console.ReadLine());
            long secondsPerStep = long.Parse(Console.ReadLine());
            leaveTime += steps * secondsPerStep;
            long seconds = leaveTime % 60;
            long minutes = leaveTime / 60 % 60;
            long hours = leaveTime / 3600 % 24;
            Console.WriteLine($"Time Arrival: {hours:d2}:{minutes:d2}:{seconds:d2}");
        }
    }
}
