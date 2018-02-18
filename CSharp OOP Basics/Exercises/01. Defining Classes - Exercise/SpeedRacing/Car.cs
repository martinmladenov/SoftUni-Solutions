// ReSharper disable CheckNamespace
public class Car
{
    public double Fuel { get; private set; }
    public double Consumption { get; }
    public int DistanceTravelled { get; private set; }

    public Car(double fuel, double consumption)
    {
        Fuel = fuel;
        Consumption = consumption;
    }

    public bool Drive(int distance)
    {
        double neededFuel = distance * Consumption;
        if (neededFuel > Fuel)
        {
            return false;
        }

        DistanceTravelled += distance;
        Fuel -= neededFuel;
        return true;
    }
}
