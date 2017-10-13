namespace _07.Inventory_Matcher
{
    using System;
    using System.Linq;

    public static class InventoryMatcher
    {
        public static void Main()
        {
            var names = Console.ReadLine().Split().ToList();
            var quantities = Console.ReadLine().Split().ToList();
            var prices = Console.ReadLine().Split().ToList();
            string input;
            while ((input = Console.ReadLine()) != "done")
            {
                int index = names.IndexOf(input);
                Console.WriteLine($"{input} costs: {prices[index]}; Available quantity: {quantities[index]}");
            }
        }
    }
}
