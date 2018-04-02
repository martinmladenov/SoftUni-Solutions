namespace InfernoInfinity.Contracts
{
    using Models.Weapons;

    public interface IWeapon
    {
        int AgilityBonus { get; }
        int MaxDamage { get; }
        int MinDamage { get; }
        WeaponRarity Rarity { get; }
        int StrengthBonus { get; }
        int VitalityBonus { get; }

        void AddGem(IGem gem, int index);
        void RemoveGem(int index);
    }
}