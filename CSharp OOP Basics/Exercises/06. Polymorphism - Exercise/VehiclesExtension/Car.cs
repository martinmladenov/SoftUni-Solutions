namespace VehiclesExtension
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption + 0.9, tankCapacity)
        {
        }
    }
}
