// ReSharper disable CheckNamespace

using System.Linq;

public class Car
{
    public string Model { get; }
    public int EngineSpeed { get; }
    public int EnginePower { get; }
    public int CargoWeight { get; }
    public string CargoType { get; }
    public Tire[] Tires { get; }

    public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType, Tire[] tires)
    {
        Model = model;
        EngineSpeed = engineSpeed;
        EnginePower = enginePower;
        CargoWeight = cargoWeight;
        CargoType = cargoType;
        Tires = tires;
    }

    public bool IsFragile
        => CargoType == "fragile" && Tires.Any(t => t.Pressure < 1);

    public bool IsFlamable
        => CargoType == "flamable" && EnginePower > 250;



}
