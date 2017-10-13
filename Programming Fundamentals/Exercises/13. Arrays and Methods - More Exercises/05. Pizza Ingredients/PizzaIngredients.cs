namespace _05.Pizza_Ingredients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class PizzaIngredients
    {
        public static void Main()
        {
            var ingredients = Console.ReadLine().Split().ToArray();
            int targetLength = int.Parse(Console.ReadLine());
            var addedIngredients = new List<string>();
            foreach (var s in ingredients.Where(s => s.Length == targetLength))
            {
                if (addedIngredients.Count >= 10)
                    break;
                addedIngredients.Add(s);
                Console.WriteLine($"Adding {s}.");
            }
            Console.WriteLine($"Made pizza with total of {addedIngredients.Count} ingredients.");
            Console.WriteLine($"The ingredients are: {string.Join(", ", addedIngredients)}.");
        }
    }
}
