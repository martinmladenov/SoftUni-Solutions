using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class DraftManager
{
    private string mode;

    private Dictionary<string, Harvester> harvesters;
    private Dictionary<string, Provider> providers;

    private double totalStoredEnergy;
    private double totalMinedOre;

    public DraftManager()
    {
        mode = "Full";

        harvesters = new Dictionary<string, Harvester>();
        providers = new Dictionary<string, Provider>();

        totalStoredEnergy = 0;
        totalMinedOre = 0;
    }

    public string RegisterHarvester(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];

        try
        {
            harvesters.Add(id, HarvesterFactory.Create(arguments));
        }
        catch (ArgumentException e)
        {
            return $"Harvester is not registered, because of it's {e.Message}";
        }

        return $"Successfully registered {type} Harvester - {id}";

    }

    public string RegisterProvider(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];

        try
        {
            providers.Add(id, ProviderFactory.Create(arguments));
        }
        catch (ArgumentException e)
        {
            return $"Provider is not registered, because of it's {e.Message}";
        }

        return $"Successfully registered {type} Provider - {id}";
    }

    public string Day()
    {
        double energyProvided = providers.Values.Sum(p => p.EnergyOutput);
        totalStoredEnergy += energyProvided;

        double energyRequired = harvesters.Values.Sum(h => h.EnergyRequirement);
        double oreProduced = 0;

        if (totalStoredEnergy >= energyRequired)
        {
            if (mode == "Full")
            {
                oreProduced = harvesters.Values.Sum(h => h.OreOutput);
            }
            else if (mode == "Half")
            {
                energyRequired *= 0.6;
                oreProduced = harvesters.Values.Sum(h => h.OreOutput) * 0.5;
            }
            else if (mode == "Energy")
            {
                energyRequired = 0;
                oreProduced = 0;
            }

            totalStoredEnergy -= energyRequired;
            totalMinedOre += oreProduced;
        }

        return $"A day has passed.{Environment.NewLine}" +
               $"Energy Provided: {energyProvided}{Environment.NewLine}" +
               $"Plumbus Ore Mined: {oreProduced}";

    }

    public string Mode(List<string> arguments)
    {
        mode = arguments[0];

        return $"Successfully changed working mode to {mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        string id = arguments[0];

        if (harvesters.ContainsKey(id))
        {
            return harvesters[id].ToString();
        }

        if (providers.ContainsKey(id))
        {
            return providers[id].ToString();
        }

        return $"No element found with id - {id}";
    }

    public string ShutDown()
    {
        return $"System Shutdown{Environment.NewLine}" +
               $"Total Energy Stored: {totalStoredEnergy}{Environment.NewLine}" +
               $"Total Mined Plumbus Ore: {totalMinedOre}";
    }
}
