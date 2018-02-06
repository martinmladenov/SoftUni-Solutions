namespace _10._Predicate_Party
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PredicateParty
    {
        public static void Main()
        {
            string[] people = Console.ReadLine().Split();

            string input;
            while ((input = Console.ReadLine()) != "Party!")
            {
                var split = input.Split();

                string funcName = split[0];
                string criteriaName = split[1];
                string argument = split[2];

                Func<string[], Predicate<string>, string[]> func = null;

                if (funcName == "Remove")
                {
                    func = (names, crit) => names.Where(s => !crit(s)).ToArray();
                }
                else if (funcName == "Double")
                {
                    func = (names, crit) =>
                    {
                        List<string> doubled = new List<string>();
                        foreach (var name in names)
                        {
                            if (crit(name))
                            {
                                doubled.Add(name);
                            }

                            doubled.Add(name);
                        }

                        return doubled.ToArray();
                    };
                }

                Predicate<string> criteria = null;

                if (criteriaName == "StartsWith")
                {
                    criteria = name => name.StartsWith(argument);
                }
                else if (criteriaName == "EndsWith")
                {
                    criteria = name => name.EndsWith(argument);
                }
                else if (criteriaName == "Length")
                {
                    criteria = name => name.Length == int.Parse(argument);
                }

                people = func(people, criteria);
            }

            if (people.Length > 0)
            {
                Console.WriteLine($"{string.Join(", ", people)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
