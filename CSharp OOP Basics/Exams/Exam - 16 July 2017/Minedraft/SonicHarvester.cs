public class SonicHarvester : Harvester
{
    private int sonicFactor;

    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor) : base(id, oreOutput, energyRequirement)
    {
        SonicFactor = sonicFactor;

        EnergyRequirement /= SonicFactor;
    }

    public int SonicFactor
    {
        get => sonicFactor;
        private set => sonicFactor = value;
    }
}