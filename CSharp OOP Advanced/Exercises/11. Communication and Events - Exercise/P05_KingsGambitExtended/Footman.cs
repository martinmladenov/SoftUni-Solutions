namespace P05_KingsGambitExtended
{
    using System;

    public class Footman : Soldier
    {
        public Footman(string name) : base(name, 2)
        {
        }

        public override void OnKingAttack(object source, EventArgs args)
        {
            Console.WriteLine($"Footman {Name} is panicking!");
        }
    }
}
