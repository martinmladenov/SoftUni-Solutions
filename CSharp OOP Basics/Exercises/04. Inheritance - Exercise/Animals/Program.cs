namespace Animals
{
    using System;
    using Animals;

    public class Program
    {
        public static void Main()
        {
            string input;
            while ((input = Console.ReadLine()) != "Beast!")
            {
                var animalData = Console.ReadLine().Split();

                try
                {
                    Animal animal = AnimalFactory.MakeAnimal(input, animalData);
                    Console.WriteLine(animal);
                }
                catch (AnimalArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
