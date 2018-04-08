namespace P02_KingsGambit
{
    using System;

    public class Footman : Soldier
    {
        public Footman(string name) : base(name)
        {
        }

        public override void OnKingAttack(object source, EventArgs args)
        {
            Console.WriteLine($"Footman {Name} is panicking!");
        }
    }
}
