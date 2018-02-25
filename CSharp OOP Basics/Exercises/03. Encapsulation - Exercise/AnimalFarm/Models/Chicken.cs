namespace AnimalFarm.Models
{
    using System;

    public class Chicken
    {
        private const int MinAge = 0;
        private const int MaxAge = 15;

        private string name;
        private int age;

        internal Chicken(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty.");
                }

                this.name = value;
            }
        }

        public int Age
        {
            get => this.age;

            private set
            {
                if (value < MinAge || value > MaxAge)
                {
                    throw new ArgumentException($"Age should be between {MinAge} and {MaxAge}.");
                }

                this.age = value;
            }
        }

        public double ProductPerDay => this.CalculateProductPerDay();

        private double CalculateProductPerDay()
        {
            switch (this.Age)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    return 1.5;
                case 4:
                case 5:
                case 6:
                case 7:
                    return 2;
                case 8:
                case 9:
                case 10:
                case 11:
                    return 1;
                default:
                    return 0.75;
            }
        }
    }
}
