namespace _01.Phonebook
{
    using System;
    using System.Collections.Generic;

    public static class Phonebook
    {
        public static void Main()
        {
            var contacts = new Dictionary<string, string>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var split = input.Split();
                string operation = split[0];
                string name = split[1];
                switch (operation)
                {
                    case "A":
                        string number = split[2];
                        contacts[name] = number;
                        break;

                    case "S":
                        Console.WriteLine(contacts.ContainsKey(name)
                            ? $"{name} -> {contacts[name]}"
                            : $"Contact {name} does not exist.");
                        break;
                }
            }
        }
    }
}
