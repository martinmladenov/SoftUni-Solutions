namespace Animals.Animals
{
    using System;

    public abstract class Animal : ISoundProducable
    {
        private string name;
        private int age;
        private string gender;

        protected Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name
        {
            get => name;
            set
            {
                if (value.Length < 1)
                {
                    throw new AnimalArgumentException();
                }

                name = value;
            }
        }

        public int Age
        {
            get => age;
            set
            {
                if (value < 0)
                {
                    throw new AnimalArgumentException();
                }

                age = value;
            }
        }

        public string Gender
        {
            get => gender;
            set
            {
                if (value.Length < 1)
                {
                    throw new AnimalArgumentException();
                }

                gender = value;
            }
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            return $"{this.GetType().Name}{Environment.NewLine}" +
                   $"{Name} {Age} {Gender}{Environment.NewLine}" +
                   $"{ProduceSound()}";
        }
    }
}
