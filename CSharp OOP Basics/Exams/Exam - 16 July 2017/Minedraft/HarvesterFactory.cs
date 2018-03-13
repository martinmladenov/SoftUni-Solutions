using System.Collections.Generic;

public static class HarvesterFactory
{
    public static Harvester Create(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        double oreOutput = double.Parse(arguments[2]);
        double energyRequirement = double.Parse(arguments[3]);

        Harvester result = null;

        if (type == "Hammer")
        {
            result = new HammerHarvester(id, oreOutput, energyRequirement);
        }
        else if (type == "Sonic")
        {
            int sonicFactor = int.Parse(arguments[4]);
            result = new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);
        }

        return result;
    }
}