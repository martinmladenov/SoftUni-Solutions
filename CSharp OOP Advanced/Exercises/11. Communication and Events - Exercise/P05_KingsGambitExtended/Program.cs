namespace P05_KingsGambitExtended
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            King king = new King(Console.ReadLine());

            List<Soldier> soldiers = new List<Soldier>();

            foreach (var name in Console.ReadLine().Split())
            {
                RoyalGuard guard = new RoyalGuard(name);
                king.KingAttack += guard.OnKingAttack;
                soldiers.Add(guard);
            }

            foreach (var name in Console.ReadLine().Split())
            {
                Footman footman = new Footman(name);
                king.KingAttack += footman.OnKingAttack;
                soldiers.Add(footman);
            }

            foreach (var soldier in soldiers)
            {
                soldier.SoldierDeath += (obj, args) =>
                {
                    Soldier killed = (Soldier)obj;

                    king.KingAttack -= killed.OnKingAttack;
                    soldiers.Remove(killed);
                };
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                if (input == "Attack King")
                {
                    king.Attack();
                }
                else if (input.StartsWith("Kill "))
                {
                    string name = input.Split()[1];

                    Soldier soldier = soldiers.FirstOrDefault(s => s.Name == name);

                    soldier.TakeDamage();
                }
            }

        }
    }
}
