namespace ComparingObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<Person> people = new List<Person>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var split = input.Split();
                people.Add(new Person(split[0], int.Parse(split[1]), split[2]));
            }

            Person target = people[int.Parse(Console.ReadLine()) - 1];

            int matches = people.Count(p => p.CompareTo(target) == 0);

            if (matches <= 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{matches} {people.Count - matches} {people.Count}");
            }
        }
    }
}
