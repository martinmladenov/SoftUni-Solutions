namespace InfernoInfinity.Core.Factories
{
    using System;
    using Contracts;
    using Models.Weapons;

    public class WeaponFactory
    {
        public IWeapon CreateWeapon(string typeName, string rarityName)
        {
            WeaponRarity rarity = Enum.Parse<WeaponRarity>(rarityName, true);

            return (IWeapon)Activator.CreateInstance(Type.GetType("InfernoInfinity.Models.Weapons." + typeName), rarity);
        }
    }
}
