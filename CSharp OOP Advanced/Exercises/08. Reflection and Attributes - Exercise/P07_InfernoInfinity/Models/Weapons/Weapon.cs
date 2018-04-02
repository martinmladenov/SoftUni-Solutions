namespace InfernoInfinity.Models.Weapons
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public abstract class Weapon : IWeapon
    {
        private readonly IGem[] gems;
        private readonly int minDamage;
        private readonly int maxDamage;

        protected Weapon(int minDamage, int maxDamage, int sockets, WeaponRarity rarity)
        {
            gems = new IGem[sockets];
            this.minDamage = minDamage;
            this.maxDamage = maxDamage;
            Rarity = rarity;
        }

        public int MinDamage => minDamage * (int)Rarity
                                + StrengthBonus * 2
                                + AgilityBonus * 1;

        public int MaxDamage => maxDamage * (int)Rarity
                                + StrengthBonus * 3
                                + AgilityBonus * 4;

        public WeaponRarity Rarity { get; }


        public int StrengthBonus => NonNullGems.Sum(g => g.StrengthBonus);

        public int AgilityBonus => NonNullGems.Sum(g => g.AgilityBonus);

        public int VitalityBonus => NonNullGems.Sum(g => g.VitalityBonus);


        private IEnumerable<IGem> NonNullGems => gems.Where(g => g != null);

        public void AddGem(IGem gem, int index)
        {
            if (index < 0 || index >= gems.Length)
            {
                return;
            }

            gems[index] = gem;
        }

        public void RemoveGem(int index)
        {
            AddGem(null, index);
        }

        public override string ToString()
        {
            return $"{MinDamage}-{MaxDamage} Damage, +{StrengthBonus} Strength, +{AgilityBonus} Agility, +{VitalityBonus} Vitality";
        }
    }
}
