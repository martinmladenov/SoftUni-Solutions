namespace _05._Filter_By_Age
{
    using System;

    public class FilterByAge
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Person[] people = new Person[n];
            for (int i = 0; i < n; i++)
            {
                string[] split = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                string name = split[0];
                int age = int.Parse(split[1]);
                people[i] = new Person(name, age);
            }

            string filterName = Console.ReadLine();
            int filterAge = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Predicate<int> filter = null;
            if (filterName == "older")
            {
                filter = i => i >= filterAge;
            }
            else if (filterName == "younger")
            {
                filter = i => i < filterAge;
            }

            if (format == "name")
            {
                format = "{0}";
            }
            else if (format == "age")
            {
                format = "{1}";
            }
            else if (format == "name age")
            {
                format = "{0} - {1}";
            }

            foreach (var person in people)
            {
                if (filter(person.Age))
                {
                    Console.WriteLine(format, person.Name, person.Age);
                }
            }
        }
    }

    class Person
    {
        public string Name { get; }
        public int Age { get; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
