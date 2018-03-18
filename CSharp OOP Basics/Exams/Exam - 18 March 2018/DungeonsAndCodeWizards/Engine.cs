namespace DungeonsAndCodeWizards
{
    using System;
    using System.Linq;

    public class Engine
    {
        private DungeonMaster dungeonMaster;

        public Engine(DungeonMaster dungeonMaster)
        {
            this.dungeonMaster = dungeonMaster;
        }

        public bool IsGameOver() => dungeonMaster.IsGameOver();

        public string GetStats() => dungeonMaster.GetStats();

        public string ProcessCommand(string[] splitCommand)
        {
            string cmd = splitCommand[0];
            string[] args = splitCommand.Skip(1).ToArray();

            string output = null;
            
            try
            {
                switch (cmd)
                {
                    case "JoinParty":
                        output = dungeonMaster.JoinParty(args);
                        break;
                    case "AddItemToPool":
                        output = dungeonMaster.AddItemToPool(args);
                        break;
                    case "PickUpItem":
                        output = dungeonMaster.PickUpItem(args);
                        break;
                    case "UseItem":
                        output = dungeonMaster.UseItem(args);
                        break;
                    case "UseItemOn":
                        output = dungeonMaster.UseItemOn(args);
                        break;
                    case "GiveCharacterItem":
                        output = dungeonMaster.GiveCharacterItem(args);
                        break;
                    case "GetStats":
                        output = dungeonMaster.GetStats();
                        break;
                    case "Attack":
                        output = dungeonMaster.Attack(args);
                        break;
                    case "Heal":
                        output = dungeonMaster.Heal(args);
                        break;
                    case "EndTurn":
                        output = dungeonMaster.EndTurn(args);
                        break;
                    case "IsGameOver":
                        output = dungeonMaster.IsGameOver().ToString();
                        break;
                }
            }
            catch (ArgumentException ex)
            {
                output = "Parameter Error: " + ex.Message;
            }
            catch (InvalidOperationException ex)
            {
                output = "Invalid Operation: " + ex.Message;
            }

            return output;
        }
    }
}
