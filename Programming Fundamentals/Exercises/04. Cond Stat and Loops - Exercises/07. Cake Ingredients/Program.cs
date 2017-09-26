using System;

namespace _07.Cake_Ingredients
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            int counter = 0;
            while ((input = Console.ReadLine()) != "Bake!")
            {
                counter++;
                Console.WriteLine($"Adding ingredient {input}.");
            }
            Console.WriteLine($"Preparing cake with {counter} ingredients.");
        }
    }
}
