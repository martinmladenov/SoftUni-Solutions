namespace Vehicles
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();

            Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
            Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split();

                string action = line[0];
                string targetName = line[1];
                double amount = double.Parse(line[2]);

                Vehicle target = null;
                if (targetName == "Car")
                {
                    target = car;
                }
                else if (targetName == "Truck")
                {
                    target = truck;
                }

                if (action == "Drive")
                {
                    if (target.Drive(amount))
                    {
                        Console.WriteLine($"{targetName} travelled {amount} km");
                    }
                    else
                    {
                        Console.WriteLine($"{targetName} needs refueling");
                    }
                }
                else if (action == "Refuel")
                {
                    target.Refuel(amount);
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
        }
    }
}
