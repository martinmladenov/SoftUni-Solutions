namespace StrategyPattern
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var nameSet = new SortedSet<Person>(new NameComparer());
            var ageSet = new SortedSet<Person>(new AgeComparer());

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                Person person = new Person(data[0], int.Parse(data[1]));
                nameSet.Add(person);
                ageSet.Add(person);
            }

            foreach (var person in nameSet)
            {
                Console.WriteLine(person);
            }

            foreach (var person in ageSet)
            {
                Console.WriteLine(person);
            }
        }
    }
}
