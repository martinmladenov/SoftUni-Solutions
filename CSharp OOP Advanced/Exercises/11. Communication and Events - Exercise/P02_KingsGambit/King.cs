namespace P02_KingsGambit
{
    using System;

    public class King : INameable
    {
        public event EventHandler KingAttack;

        public King(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public void Attack()
        {
            Console.WriteLine($"King {Name} is under attack!");

            KingAttack?.Invoke(this, EventArgs.Empty);
        }
    }
}
