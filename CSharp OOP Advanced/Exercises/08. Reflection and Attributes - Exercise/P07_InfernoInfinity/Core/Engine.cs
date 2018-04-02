namespace InfernoInfinity.Core
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Factories;

    public class Engine
    {
        private Dictionary<string, IWeapon> weapons;
        private WeaponFactory weaponFactory;
        private GemFactory gemFactory;

        public Engine()
        {
            weapons = new Dictionary<string, IWeapon>();
            weaponFactory = new WeaponFactory();
            gemFactory = new GemFactory();
        }

        public void InterpretCommand(string command)
        {
            string[] split = command.Split(';');

            switch (split[0])
            {
                case "Create":
                    string[] weaponData = split[1].Split();
                    IWeapon weapon = weaponFactory.CreateWeapon(weaponData[1], weaponData[0]);

                    weapons.Add(split[2], weapon);
                    break;

                case "Add":
                    string[] gemData = split[3].Split();
                    IGem gem = gemFactory.CreateGem(gemData[1], gemData[0]);

                    weapons[split[1]].AddGem(gem, int.Parse(split[2]));
                    break;

                case "Remove":
                    weapons[split[1]].RemoveGem(int.Parse(split[2]));
                    break;

                case "Print":
                    Console.WriteLine($"{split[1]}: {weapons[split[1]]}");
                    break;
            }
        }
    }
}
