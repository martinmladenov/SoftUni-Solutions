namespace DungeonsAndCodeWizards
{
    using System;

    public class CharacterFactory
    {
        public Character CreateCharacter(string factionName, string characterType, string name)
        {
            if (!Enum.TryParse(factionName, out Faction faction))
            {
                throw new ArgumentException($"Invalid faction \"{factionName}\"!");
            }

            Character character;

            switch (characterType)
            {
                case "Cleric":
                    character = new Cleric(name, faction);
                    break;
                case "Warrior":
                    character = new Warrior(name, faction);
                    break;
                default:
                    throw new ArgumentException($"Invalid character type \"{characterType}\"!");
            }

            return character;
        }
    }
}