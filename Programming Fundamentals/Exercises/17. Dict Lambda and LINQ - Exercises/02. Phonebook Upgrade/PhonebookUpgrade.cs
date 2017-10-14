namespace _02.Phonebook_Upgrade
{
    using System;
    using System.Collections.Generic;

    public static class PhonebookUpgrade
    {
        public static void Main()
        {
            var contacts = new SortedDictionary<string, string>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var split = input.Split();
                string name;
                switch (split[0])
                {
                    case "A":
                        name = split[1];
                        string number = split[2];
                        contacts[name] = number;
                        break;

                    case "S":
                        name = split[1];
                        Console.WriteLine(contacts.ContainsKey(name)
                            ? $"{name} -> {contacts[name]}"
                            : $"Contact {name} does not exist.");
                        break;

                    case "ListAll":
                        foreach (var pair in contacts)
                        {
                            Console.WriteLine($"{pair.Key} -> {pair.Value}");
                        }
                        break;
                }
            }
        }
    }
}
