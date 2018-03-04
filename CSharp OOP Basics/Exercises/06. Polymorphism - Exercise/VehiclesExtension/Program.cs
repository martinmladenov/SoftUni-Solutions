namespace VehiclesExtension
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            string[] busInfo = Console.ReadLine().Split();

            Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
            Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
            Bus bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

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
                else if (targetName == "Bus")
                {
                    target = bus;
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
                else if (action == "DriveEmpty")
                {
                    if (((Bus)target).DriveEmpty(amount))
                    {
                        Console.WriteLine($"Bus travelled {amount} km");
                    }
                    else
                    {
                        Console.WriteLine("Bus needs refueling");
                    }
                }
                else if (action == "Refuel")
                {
                    target.Refuel(amount);
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}
