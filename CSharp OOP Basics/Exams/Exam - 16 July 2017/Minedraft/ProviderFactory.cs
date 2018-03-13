using System.Collections.Generic;

public static class ProviderFactory
{
    public static Provider Create(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        double energyOutput = double.Parse(arguments[2]);

        Provider result = null;

        if (type == "Solar")
        {
            result = new SolarProvider(id, energyOutput);
        }
        else if (type == "Pressure")
        {
            result = new PressureProvider(id, energyOutput);
        }

        return result;
    }
}