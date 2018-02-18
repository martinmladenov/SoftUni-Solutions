using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable CheckNamespace

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Car[] cars = new Car[n];

        for (int i = 0; i < n; i++)
        {
            string[] split = Console.ReadLine().Split();
            string model = split[0];
            int engineSpeed = int.Parse(split[1]);
            int enginePower = int.Parse(split[2]);
            int cargoWeight = int.Parse(split[3]);
            string cargoType = split[4];

            Tire[] tires = new Tire[4];
            for (int tireIndex = 0; tireIndex < 4; tireIndex++)
            {
                int paramIndex = 5 + 2 * tireIndex;
                double pressure = double.Parse(split[paramIndex]);
                int age = int.Parse(split[paramIndex + 1]);
                tires[tireIndex] = new Tire(pressure, age);
            }

            cars[i] = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, tires);
        }

        string typeToPrint = Console.ReadLine();

        if (typeToPrint == "fragile")
        {
            foreach (var car in cars.Where(c => c.IsFragile))
            {
                Console.WriteLine(car.Model);
            }
        }
        else if (typeToPrint == "flamable")
        {
            foreach (var car in cars.Where(c => c.IsFlamable))
            {
                Console.WriteLine(car.Model);
            }
        }

    }
}
