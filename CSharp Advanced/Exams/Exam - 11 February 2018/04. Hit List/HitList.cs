namespace _04._Hit_List
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HitList
    {
        public static void Main()
        {
            var people = new Dictionary<string, Dictionary<string, string>>();
            int targetInfoIndex = int.Parse(Console.ReadLine());

            string input;
            while ((input = Console.ReadLine()) != "end transmissions")
            {
                string[] split = input.Split('=');
                string name = split[0];
                string[] data = split[1].Split(';');

                if (!people.ContainsKey(name))
                {
                    people.Add(name, new Dictionary<string, string>());
                }

                var personDict = people[name];

                foreach (var info in data)
                {
                    string[] infoSplit = info.Split(':');
                    string key = infoSplit[0];
                    string value = infoSplit[1];
                    personDict[key] = value;
                }
            }

            string killName = Console.ReadLine().Substring(5);

            Console.WriteLine($"Info on {killName}:");
            foreach (var info in people[killName].OrderBy(kvp => kvp.Key))
            {
                Console.WriteLine($"---{info.Key}: {info.Value}");
            }

            int infoIndex = people[killName].Sum(kvp => kvp.Key.Length + kvp.Value.Length);

            Console.WriteLine($"Info index: {infoIndex}");

            if (infoIndex >= targetInfoIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {targetInfoIndex - infoIndex} more info.");
            }
        }
    }
}