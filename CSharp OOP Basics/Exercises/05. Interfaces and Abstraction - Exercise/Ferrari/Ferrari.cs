using System;

public class Ferrari : ICar
{
    public string UseBrakes()
    {
        return "Brakes!";
    }

    public string PushGas()
    {
        return "Zadu6avam sA!";
    }

    public Ferrari(Driver driver)
    {
        Driver = driver;
    }

    public string Model => "488-Spider";
    public Driver Driver { get; }

    public override string ToString()
    {
        return $"{Model}/{UseBrakes()}/{PushGas()}/{Driver.Name}";
    }
}