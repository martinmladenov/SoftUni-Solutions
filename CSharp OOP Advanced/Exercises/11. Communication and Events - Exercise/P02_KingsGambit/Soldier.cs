namespace P02_KingsGambit
{
    using System;

    public abstract class Soldier : INameable
    {
        protected Soldier(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public abstract void OnKingAttack(object source, EventArgs args);
    }
}
