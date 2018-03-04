namespace WildFarm.Models
{
    using System;

    public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; }
        public double Weight { get; internal set; }
        public int FoodEaten { get; internal set; }
        public abstract double WeightIncrease { get; }

        protected abstract bool Eats(Food food);

        public void Eat(Food food)
        {
            if (!Eats(food))
            {
                Console.WriteLine($"{GetType().Name} does not eat {food.GetType().Name}!");
                return;
            }

            FoodEaten += food.Quantity;
            Weight += WeightIncrease * food.Quantity;
        }

        public abstract string Sound { get; }
    }
}
