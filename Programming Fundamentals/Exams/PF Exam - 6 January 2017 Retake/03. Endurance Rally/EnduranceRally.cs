namespace _03.Endurance_Rally
{
    using System;
    using System.Linq;

    public class EnduranceRally
    {
        public static void Main()
        {
            var drivers = Console.ReadLine().Split();
            var zones = Console.ReadLine().Split().Select(double.Parse).ToArray();
            var checkpointIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int zoneIndex = 0; zoneIndex < zones.Length; zoneIndex++)
                if (checkpointIndexes.Contains(zoneIndex))
                    zones[zoneIndex] = -zones[zoneIndex];
            foreach (var driver in drivers)
            {
                double fuel = driver[0];
                for (var index = 0; index < zones.Length; index++)
                {
                    var zone = zones[index];
                    fuel -= zone;
                    if (fuel > 0) continue;
                    Console.WriteLine($"{driver} - reached {index}");
                    break;
                }
                if (fuel > 0)
                    Console.WriteLine($"{driver} - fuel left {fuel:f2}");
            }
        }
    }
}
