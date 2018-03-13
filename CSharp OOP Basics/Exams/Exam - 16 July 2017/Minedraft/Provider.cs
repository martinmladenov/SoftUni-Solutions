using System;

public abstract class Provider : Identifiable
{
    private double energyOutput;

    protected Provider(string id, double energyOutput) : base(id)
    {
        EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get => energyOutput;
        protected set
        {
            if (value < 0 || value >= 10000)
            {
                throw new ArgumentException(nameof(EnergyOutput));
            }

            energyOutput = value;
        }
    }

    public override string ToString()
    {
        string name = this.GetType().Name;
        name = name.Substring(0, name.IndexOf("Provider"));

        return $"{name} Provider - {Id}{Environment.NewLine}" +
               $"Energy Output: {EnergyOutput}";
    }
}