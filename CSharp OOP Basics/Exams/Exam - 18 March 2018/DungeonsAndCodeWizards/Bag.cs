namespace DungeonsAndCodeWizards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Bag
    {
        private readonly LinkedList<Item> items;
        public int Capacity { get; }
        public int Load => Items.Sum(item => item.Weight);

        public IReadOnlyCollection<Item> Items => items.ToList().AsReadOnly();

        protected Bag(int capacity)
        {
            Capacity = capacity;
            items = new LinkedList<Item>();
        }

        public void AddItem(Item item)
        {
            if (Load + item.Weight > Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            items.AddLast(item);
        }

        public Item GetItem(string name)
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }
            Item item = items.FirstOrDefault(p => p.GetType().Name == name);

            if (item == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            items.Remove(item);

            return item;
        }
    }
}
