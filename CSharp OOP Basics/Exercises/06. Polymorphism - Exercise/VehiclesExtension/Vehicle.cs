namespace VehiclesExtension
{
    using System;

    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelConsumption = fuelConsumption;

            if (fuelQuantity > 0 && fuelQuantity <= TankCapacity)
            {
                FuelQuantity = fuelQuantity;
            }
            else
            {
                FuelQuantity = 0;
            }
        }

        public double FuelQuantity { get; internal set; }

        public double TankCapacity { get; }

        public double FuelConsumption { get; }

        public virtual bool Drive(double km)
        {
            return Drive(km, FuelConsumption);
        }

        internal bool Drive(double km, double consumption)
        {
            double fuelNeeded = consumption * km;

            if (fuelNeeded > FuelQuantity)
                return false;

            FuelQuantity -= fuelNeeded;
            return true;
        }

        public virtual void Refuel(double liters)
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
                FuelQuantity += liters;
            }
        }
    }
}
