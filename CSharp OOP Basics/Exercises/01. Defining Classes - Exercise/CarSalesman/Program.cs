using System;
using System.Collections.Generic;

// ReSharper disable CheckNamespace

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var engines = new Dictionary<string, Engine>();
        for (int i = 0; i < n; i++)
        {
            var split = Console.ReadLine().Trim().Split();
            string model = split[0];
            int power = int.Parse(split[1]);
            int? displacement = null;
            string efficiency = null;
            if (split.Length == 3)
            {
                if (int.TryParse(split[2], out int parsedDisplacement))
                {
                    displacement = parsedDisplacement;
                }
                else
                {
                    efficiency = split[2];
                }
            }
            else if (split.Length == 4)
            {
                displacement = int.Parse(split[2]);
                efficiency = split[3];
            }

            engines[model] = new Engine(model, power, displacement, efficiency);
        }

        int m = int.Parse(Console.ReadLine());
        Car[] cars = new Car[m];
        for (int i = 0; i < m; i++)
        {
            var split = Console.ReadLine().Trim().Split();
            string model = split[0];
            Engine engine = engines[split[1]];
            int? weight = null;
            string color = null;
            if (split.Length == 3)
            {
                if (int.TryParse(split[2], out int parsedDisplacement))
                {
                    weight = parsedDisplacement;
                }
                else
                {
                    color = split[2];
                }
            }
            else if (split.Length == 4)
            {
                weight = int.Parse(split[2]);
                color = split[3];
            }

            cars[i] = new Car(model, engine, weight, color);
        }

        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }
    }
}
