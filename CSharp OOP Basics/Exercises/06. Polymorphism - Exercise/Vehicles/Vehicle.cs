namespace Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; private set; }
        public double FuelConsumption { get; }

        public bool Drive(double km)
        {
            double fuelNeeded = FuelConsumption * km;

            if (fuelNeeded > FuelQuantity)
                return false;

            FuelQuantity -= fuelNeeded;
            return true;
        }

        public virtual void Refuel(double liters)
        {
            FuelQuantity += liters;
        }
    }
}
