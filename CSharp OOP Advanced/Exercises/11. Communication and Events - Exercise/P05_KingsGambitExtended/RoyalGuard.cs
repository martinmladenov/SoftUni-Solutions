namespace P05_KingsGambitExtended
{
    using System;

    public class RoyalGuard : Soldier
    {
        public RoyalGuard(string name) : base(name, 3)
        {
        }

        public override void OnKingAttack(object source, EventArgs args)
        {
            Console.WriteLine($"Royal Guard {Name} is defending!");
        }
    }
}
