namespace DungeonsAndCodeWizards
{
    using System;

    public class ArmorRepairKit : Item
    {
        public ArmorRepairKit() : base(10)
        {
        }

        public override void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            character.Armor = character.BaseArmor;
        }
    }
}
