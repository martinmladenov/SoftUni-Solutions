// ReSharper disable CheckNamespace

using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var people = new Dictionary<string, Person>();
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            var split = input.Split();
            string name = split[0];

            if (!people.ContainsKey(name))
            {
                people.Add(name, new Person());
            }

            Person person = people[name];

            string infoType = split[1];

            if (infoType == "company")
            {
                person.Company = new Company(split[2], split[3], double.Parse(split[4]));
            }
            else if (infoType == "pokemon")
            {
                person.Pokemon.Add(new Pokemon(split[2], split[3]));
            }
            else if (infoType == "parents")
            {
                person.Parents.Add(new Parent(split[2], split[3]));
            }
            else if (infoType == "children")
            {
                person.Children.Add(new Child(split[2], split[3]));
            }
            else if (infoType == "car")
            {
                person.Car = new Car(split[2], int.Parse(split[3]));
            }
        }

        string nameToPrint = Console.ReadLine();
        Console.WriteLine(nameToPrint);
        people[nameToPrint].PrintInformation();
    }
}
