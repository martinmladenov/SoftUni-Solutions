namespace P02_KingsGambit
{
    using System;

    public class RoyalGuard : Soldier
    {
        public RoyalGuard(string name) : base(name)
        {
        }

        public override void OnKingAttack(object source, EventArgs args)
        {
            Console.WriteLine($"Royal Guard {Name} is defending!");
        }
    }
}
