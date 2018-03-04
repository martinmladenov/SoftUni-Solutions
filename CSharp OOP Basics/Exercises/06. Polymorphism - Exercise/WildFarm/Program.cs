namespace WildFarm
{
    using System;
    using System.Collections.Generic;
    using Models;
    using Models.Animals.Birds;
    using Models.Animals.Mammals;
    using Models.Animals.Mammals.Felines;
    using Models.Foods;

    public class Program
    {
        public static void Main()
        {
            string input;

            List<Animal> animals = new List<Animal>();

            while ((input = Console.ReadLine()) != "End")
            {
                Animal animal = ReadAnimal(input);
                Food food = ReadFood(Console.ReadLine());

                Console.WriteLine(animal.Sound);
                animal.Eat(food);

                animals.Add(animal);
            }

            animals.ForEach(Console.WriteLine);
        }

        private static Animal ReadAnimal(string str)
        {
            var data = str.Split();

            string type = data[0];
            string name = data[1];
            double weight = double.Parse(data[2]);

            Animal animal = null;

            if (type == "Owl")
            {
                double wingSize = double.Parse(data[3]);
                animal = new Owl(name, weight, wingSize);
            }
            else if (type == "Hen")
            {
                double wingSize = double.Parse(data[3]);
                animal = new Hen(name, weight, wingSize);
            }
            else if (type == "Cat")
            {
                string livingRegion = data[3];
                string breed = data[4];
                animal = new Cat(name, weight, livingRegion, breed);
            }
            else if (type == "Tiger")
            {
                string livingRegion = data[3];
                string breed = data[4];
                animal = new Tiger(name, weight, livingRegion, breed);
            }
            else if (type == "Mouse")
            {
                string livingRegion = data[3];
                animal = new Mouse(name, weight, livingRegion);
            }
            else if (type == "Dog")
            {
                string livingRegion = data[3];
                animal = new Dog(name, weight, livingRegion);
            }

            return animal;
        }

        private static Food ReadFood(string str)
        {
            var data = str.Split();

            string type = data[0];
            int amount = int.Parse(data[1]);

            Food food = null;

            if (type == "Vegetable")
            {
                food = new Vegetable(amount);
            }
            else if (type == "Fruit")
            {
                food = new Fruit(amount);
            }
            else if (type == "Seeds")
            {
                food = new Seeds(amount);
            }
            else if (type == "Meat")
            {
                food = new Meat(amount);
            }

            return food;
        }
    }
}
