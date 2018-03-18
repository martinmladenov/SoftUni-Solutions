namespace DungeonsAndCodeWizards
{
    using System;

    public class Warrior : Character, IAttackable
    {
        public Warrior(string name, Faction faction) : base(name, 100, 50, 40, new Satchel(), faction)
        {
        }

        public void Attack(Character character)
        {
            if (!IsAlive || !character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            if (character == this)
            {
                throw new InvalidOperationException("Cannot attack self!");
            }

            if (character.Faction == Faction)
            {
                throw new ArgumentException($"Friendly fire! Both characters are from {Faction} faction!");
            }

            character.TakeDamage(AbilityPoints);
        }
    }
}
