using System;
using System.Collections.Generic;

// ReSharper disable CheckNamespace

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Dictionary<string,Car> cars = new Dictionary<string, Car>();

        for (int i = 0; i < n; i++)
        {
            string[] split = Console.ReadLine().Split();
            string model = split[0];
            double fuel = double.Parse(split[1]);
            double consumption = double.Parse(split[2]);
            cars[model] = new Car(fuel, consumption);
        }

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            var split = input.Split();
            string model = split[1];
            int distance = int.Parse(split[2]);

            if (!cars[model].Drive(distance))
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Key} {car.Value.Fuel:f2} {car.Value.DistanceTravelled}");
        }
    }
}
