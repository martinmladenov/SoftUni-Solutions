namespace DungeonsAndCodeWizards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class DungeonMaster
    {
        private List<Character> party;
        private Stack<Item> itemPool;
        private int lastSurvivorRounds;

        public DungeonMaster()
        {
            party = new List<Character>();
            itemPool = new Stack<Item>();
            lastSurvivorRounds = 0;
        }

        public string JoinParty(string[] args)
        {
            string factionName = args[0];
            string characterType = args[1];
            string name = args[2];

            CharacterFactory factory = new CharacterFactory();

            Character character = factory.CreateCharacter(factionName, characterType, name);

            party.Add(character);

            return $"{character.Name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            ItemFactory factory = new ItemFactory();

            Item item = factory.CreateItem(args[0]);

            itemPool.Push(item);

            return $"{item.GetType().Name} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            Character character = party.FirstOrDefault(p => p.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            if (itemPool.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            Item item = itemPool.Pop();
            character.ReceiveItem(item);

            return $"{characterName} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = party.FirstOrDefault(p => p.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            Item item = character.Bag.GetItem(itemName);

            character.UseItem(item);

            return $"{characterName} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = party.FirstOrDefault(p => p.Name == giverName);
            Character receiver = party.FirstOrDefault(p => p.Name == receiverName);

            if (giver == null)
            {
                throw new ArgumentException($"Character {giverName} not found!");
            }

            if (receiver == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            Item item = giver.Bag.GetItem(itemName);

            receiver.UseItem(item);

            return $"{giver.Name} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = party.FirstOrDefault(p => p.Name == giverName);
            Character receiver = party.FirstOrDefault(p => p.Name == receiverName);

            if (giver == null)
            {
                throw new ArgumentException($"Character {giverName} not found!");
            }

            if (receiver == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            Item item = giver.Bag.GetItem(itemName);

            receiver.ReceiveItem(item);

            return $"{giver.Name} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            return string.Join(Environment.NewLine,
                party.OrderByDescending(character => character.IsAlive)
                    .ThenByDescending(character => character.Health));
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Character attacker = party.FirstOrDefault(p => p.Name == attackerName);
            Character receiver = party.FirstOrDefault(p => p.Name == receiverName);

            if (attacker == null)
            {
                throw new ArgumentException($"Character {attackerName} not found!");
            }

            if (receiver == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            if (!(attacker is IAttackable))
            {
                throw new ArgumentException($"{attackerName} cannot attack!");
            }

            ((IAttackable)attacker).Attack(receiver);

            string output = $"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!";

            if (!receiver.IsAlive)
            {
                output += $"{Environment.NewLine}{receiverName} is dead!";
            }

            return output;
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string receiverName = args[1];

            Character healer = party.FirstOrDefault(p => p.Name == healerName);
            Character receiver = party.FirstOrDefault(p => p.Name == receiverName);

            if (healer == null)
            {
                throw new ArgumentException($"Character {healerName} not found!");
            }

            if (receiver == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            if (!(healer is IHealable))
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }

            ((IHealable)healer).Heal(receiver);

            string output = $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";

            return output;
        }

        public string EndTurn(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            int aliveCount = 0;

            foreach (var character in party.Where(character => character.IsAlive))
            {
                sb.AppendLine(string.Format("{0} rests ({1} => {2})", character.Name, character.Health,
                    Math.Min(character.BaseHealth, character.Health + character.BaseHealth * character.RestHealMultiplier)));
                character.Rest();
                aliveCount++;
            }

            if (aliveCount <= 1)
                lastSurvivorRounds++;
            else
                lastSurvivorRounds = 0;

            return sb.ToString().Trim();
        }

        public bool IsGameOver() => lastSurvivorRounds > 1;

    }
}
