namespace _06.Truck_Tour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TruckTour
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var pumps = new Queue<Pump>();
            for (int i = 0; i < n; i++)
            {
                var split = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                pumps.Enqueue(new Pump(split[0], split[1]));
            }

            for (int index = 0; index < n; index++)
            {
                int currentFuel = 0;

                int i = 0;

                do
                {
                    var pump = pumps.Dequeue();
                    currentFuel += pump.FuelAmount - pump.Distance;
                    pumps.Enqueue(pump);

                } while (++i < n && currentFuel >= 0);

                if (i != n)
                {
                    for (int j = i; j <= n; j++)
                    {
                        pumps.Enqueue(pumps.Dequeue());
                    }

                    continue;
                }

                Console.WriteLine(index);
                break;
            }
        }

        class Pump
        {
            public int FuelAmount { get; }
            public int Distance { get; }

            public Pump(int fuelAmount, int distance)
            {
                FuelAmount = fuelAmount;
                Distance = distance;
            }
        }
    }
}
