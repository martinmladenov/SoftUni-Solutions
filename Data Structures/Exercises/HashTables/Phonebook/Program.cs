namespace Phonebook
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            HashTable<string, string> phonebook = new HashTable<string, string>();

            string input;
            while ((input = Console.ReadLine()) != "search")
            {
                var data = input.Split('-');
                phonebook.Add(data[0], data[1]);
            }

            while ((input = Console.ReadLine()) != "end")
            {
                if (phonebook.ContainsKey(input))
                {
                    Console.WriteLine($"{input} -> {phonebook[input]}");
                }
                else
                {
                    Console.WriteLine($"Contact {input} does not exist.");
                }
            }
        }
    }
}
