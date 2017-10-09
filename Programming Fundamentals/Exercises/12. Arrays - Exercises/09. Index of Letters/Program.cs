namespace _09.Index_of_Letters
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            foreach (var c in input)
            {
                Console.WriteLine($"{c} -> {c - 'a'}");
            }
        }
    }
}
