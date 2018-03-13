using System;

public abstract class Harvester : Identifiable
{
    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement) : base(id)
    {
        OreOutput = oreOutput;
        EnergyRequirement = energyRequirement;
    }

    public double OreOutput
    {
        get => oreOutput;
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException(nameof(OreOutput));
            }

            oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get => energyRequirement;
        protected set
        {
            if (value < 0 || value > 20000)
            {
                throw new ArgumentException(nameof(EnergyRequirement));
            }

            energyRequirement = value;
        }
    }

    public override string ToString()
    {
        string name = this.GetType().Name;
        name = name.Substring(0, name.IndexOf("Harvester"));

        return $"{name} Harvester - {Id}{Environment.NewLine}" +
               $"Ore Output: {OreOutput}{Environment.NewLine}" +
               $"Energy Requirement: {EnergyRequirement}";
    }
}