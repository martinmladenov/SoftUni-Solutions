namespace VehiclesExtension
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override bool Drive(double km)
        {
            return Drive(km, FuelConsumption + 1.4);
        }

        public bool DriveEmpty(double km)
        {
            return base.Drive(km);
        }


    }
}
