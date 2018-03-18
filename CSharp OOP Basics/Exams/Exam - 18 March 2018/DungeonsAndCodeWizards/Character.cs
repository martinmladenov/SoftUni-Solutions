namespace DungeonsAndCodeWizards
{
    using System;

    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            Name = name;
            BaseHealth = health;
            Health = health;
            BaseArmor = armor;
            Armor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
            Faction = faction;

            IsAlive = true;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                name = value;
            }
        }

        public double BaseHealth { get; }

        public double Health
        {
            get => health;
            set
            {
                if (value < 0)
                    value = 0;
                else if (value > BaseHealth)
                    value = BaseHealth;

                health = value;

                if (health == 0)
                {
                    IsAlive = false;
                }
            }
        }

        public double BaseArmor { get; }

        public double Armor
        {
            get => armor;
            set
            {
                if (value < 0)
                    value = 0;
                else if (value > BaseArmor)
                    value = BaseArmor;

                armor = value;
            }
        }

        public double AbilityPoints { get; }

        public Bag Bag { get; }

        public Faction Faction { get; }

        public bool IsAlive { get; private set; }

        public virtual double RestHealMultiplier => 0.2;

        public void TakeDamage(double hitPoints)
        {
            if (!IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            double healthPoints = hitPoints - Armor;

            Armor -= hitPoints;

            if (healthPoints > 0)
            {
                Health -= healthPoints;
            }
        }

        public void Rest()
        {
            if (!IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            Health += BaseHealth * RestHealMultiplier;
        }

        public void UseItem(Item item)
        {
            if (!IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            if (!IsAlive || !character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            if (!IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            character.ReceiveItem(item);
        }

        public void ReceiveItem(Item item)
        {
            if (!IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }

            Bag.AddItem(item);
        }

        public override string ToString()
        {
            return $"{Name} - HP: {Health}/{BaseHealth}, AP: {armor}/{BaseArmor}, Status: {(IsAlive ? "Alive" : "Dead")}";
        }
    }
}
