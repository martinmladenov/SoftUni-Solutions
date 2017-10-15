namespace _03.Immune_System
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class ImmuneSystem
    {
        public static void Main()
        {
            var knownViruses = new List<string>();
            int originalSystemStrength = int.Parse(Console.ReadLine());
            int systemStrength = originalSystemStrength;
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                int virusStrength = input
                    .ToCharArray()
                    .Sum(c => c) / 3;
                int virusTime = virusStrength * input.Length;
                if (knownViruses.Contains(input))
                    virusTime /= 3;
                else
                    knownViruses.Add(input);
                Console.WriteLine($"Virus {input}: {virusStrength} => {virusTime} seconds");
                systemStrength -= virusTime;
                if (systemStrength <= 0) break;
                Console.WriteLine($"{input} defeated in {virusTime / 60}m {virusTime % 60}s.");
                Console.WriteLine($"Remaining health: {systemStrength}");
                systemStrength = Math.Min(originalSystemStrength,
                    (int)(systemStrength * 1.2));
            }
            Console.WriteLine(systemStrength > 0 ?
                $"Final Health: {systemStrength}" :
                "Immune System Defeated.");
        }
    }
}
