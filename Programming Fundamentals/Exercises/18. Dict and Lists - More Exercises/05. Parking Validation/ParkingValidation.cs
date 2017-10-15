namespace _05.Parking_Validation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class ParkingValidation
    {
        public static void Main()
        {
            var registered = new Dictionary<string, string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var split = Console.ReadLine().Split();
                string name = split[1];
                switch (split[0])
                {
                    case "register":
                        string plate = split[2];
                        if (registered.ContainsKey(name))
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {registered[name]}");
                            continue;
                        }
                        if (!IsPlateValid(plate))
                        {
                            Console.WriteLine($"ERROR: invalid license plate {plate}");
                            continue;
                        }
                        if (registered.Any(kvp => kvp.Value == plate))
                        {
                            Console.WriteLine($"ERROR: license plate {plate} is busy");
                            continue;
                        }
                        Console.WriteLine($"{name} registered {plate} successfully");
                        registered[name] = plate;
                        break;

                    case "unregister":
                        if (!registered.ContainsKey(name))
                        {
                            Console.WriteLine($"ERROR: user {name} not found");
                            continue;
                        }
                        Console.WriteLine($"user {name} unregistered successfully");
                        registered.Remove(name);
                        break;
                }
            }
            foreach (var plate in registered)
            {
                Console.WriteLine($"{plate.Key} => {plate.Value}");
            }
        }

        private static bool IsPlateValid(string plate)
        {
            return
                plate.Length == 8
                && plate
                .Take(2)
                .All(c => c >= 'A' && c <= 'Z')
                && plate
                .Skip(2)
                .Take(4)
                .All(c => c >= '0' && c <= '9')
                && plate
                .Skip(6)
                .Take(2)
                .All(c => c >= 'A' && c <= 'Z');
        }
    }
}
