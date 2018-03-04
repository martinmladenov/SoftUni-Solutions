namespace VehiclesExtension
{
    using System;

    public class Truck : Vehicle
    {

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption + 1.6, tankCapacity)
        {
        }

        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (FuelQuantity + liters > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }
            else
            {
                FuelQuantity += liters * 0.95;
            }
        }
    }
}
