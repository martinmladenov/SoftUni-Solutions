namespace InfernoInfinity.Contracts
{
    using Models.Gems;

    public interface IGem
    {
        int AgilityBonus { get; }
        GemClarity Clarity { get; }
        int StrengthBonus { get; }
        int VitalityBonus { get; }
    }
}