namespace _11._Party_Reservation_Filter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PartyReservationFilterModule
    {
        public static void Main()
        {
            string[] people = Console.ReadLine().Split();

            Dictionary<string, Predicate<string>> filters = new Dictionary<string, Predicate<string>>();

            string input;
            while ((input = Console.ReadLine()) != "Print")
            {
                var split = input.Split(';');

                string funcName = split[0];
                string filterName = split[1];
                string argument = split[2];

                string filterKey = $"{filterName};{argument}";

                if (funcName == "Remove filter")
                {
                    filters.Remove(filterKey);
                }
                else if (funcName == "Add filter")
                {
                    Predicate<string> filter = null;

                    if (filterName == "Starts with")
                    {
                        filter = name => name.StartsWith(argument);
                    }
                    else if (filterName == "Ends with")
                    {
                        filter = name => name.EndsWith(argument);
                    }
                    else if (filterName == "Length")
                    {
                        filter = name => name.Length == int.Parse(argument);
                    }
                    else if (filterName == "Contains")
                    {
                        filter = name => name.Contains(argument);
                    }

                    filters.Add(filterKey, filter);
                }
            }

            people = people.Where(person => !filters.Values.Any(filter => filter(person))).ToArray();

            Console.WriteLine(string.Join(" ", people));
        }
    }
}
