// ReSharper disable CheckNamespace

using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var peopleByNames = new Dictionary<string, Person>();
        var peopleByBirthdates = new Dictionary<string, Person>();

        string toPrint = Console.ReadLine();
        if (toPrint.Contains(" "))
        {
            peopleByNames[toPrint] = new Person(toPrint, null);
        }
        else
        {
            peopleByBirthdates[toPrint] = new Person(null, toPrint);
        }

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            var split = input.Split();

            if (!input.Contains("-"))
            {
                string name = $"{split[0]} {split[1]}";
                string birthdate = split[2];

                if (peopleByNames.ContainsKey(name) && peopleByBirthdates.ContainsKey(birthdate)) // merge people
                {
                    Person actualPerson = peopleByNames[name];
                    Person birthdatePerson = peopleByBirthdates[birthdate];

                    actualPerson.Birthdate = birthdate;
                    peopleByBirthdates[birthdate] = actualPerson;

                    foreach (var birthdateChild in birthdatePerson.Children)
                    {
                        actualPerson.AddChild(birthdateChild);
                        birthdateChild.Parents.Remove(birthdatePerson);
                        birthdateChild.AddParent(actualPerson);
                    }

                    foreach (var birthdateParent in birthdatePerson.Parents)
                    {
                        actualPerson.AddParent(birthdateParent);
                        birthdateParent.Children.Remove(birthdatePerson);
                        birthdateParent.AddChild(actualPerson);
                    }
                }
                else if (peopleByNames.ContainsKey(name))
                {
                    peopleByNames[name].Birthdate = birthdate;
                }
                else if (peopleByBirthdates.ContainsKey(birthdate))
                {
                    peopleByBirthdates[birthdate].Name = name;
                }

                continue;
            }


            int indexOfDash = split.ToList().IndexOf("-");

            Person parent = null, child = null;

            if (indexOfDash == 2)
            {
                string parentName = $"{split[0]} {split[1]}";
                parent = GetPersonByName(parentName, peopleByNames);

                if (split.Length == 5) // FirstName LastName - FirstName LastName
                {
                    string childName = $"{split[3]} {split[4]}";
                    child = GetPersonByName(childName, peopleByNames);
                }
                else if (split.Length == 4) // FirstName LastName - day/month/year
                {
                    string childBirthdate = split[3];
                    child = GetPersonByBirthdate(childBirthdate, peopleByBirthdates);
                }
            }
            else if (indexOfDash == 1)
            {
                string parentBirthdate = split[0];
                parent = GetPersonByBirthdate(parentBirthdate, peopleByBirthdates);

                if (split.Length == 4) // day/month/year - FirstName LastName
                {
                    string childName = $"{split[2]} {split[3]}";
                    child = GetPersonByName(childName, peopleByNames);
                }
                else if (split.Length == 3) // day/month/year - day/month/year
                {
                    string childBirthdate = split[2];
                    child = GetPersonByBirthdate(childBirthdate, peopleByBirthdates);
                }
            }

            parent.AddChild(child);
            child.AddParent(parent);
        }

        Person personToPrint;

        if (toPrint.Contains(" "))
        {
            personToPrint = peopleByNames[toPrint];
        }
        else
        {
            personToPrint = peopleByBirthdates[toPrint];
        }

        Console.WriteLine(personToPrint);

        Console.WriteLine("Parents:");
        foreach (var parent in personToPrint.Parents)
        {
            Console.WriteLine(parent);
        }

        Console.WriteLine("Children:");
        foreach (var child in personToPrint.Children)
        {
            Console.WriteLine(child);
        }
    }

    private static Person GetPersonByBirthdate(string birthdate, Dictionary<string, Person> peopleByBirthdates)
    {
        if (!peopleByBirthdates.ContainsKey(birthdate))
        {
            Person newPerson = new Person(null, birthdate);
            peopleByBirthdates.Add(birthdate, newPerson);
            return newPerson;
        }

        return peopleByBirthdates[birthdate];
    }

    private static Person GetPersonByName(string name, Dictionary<string, Person> peopleByNames)
    {
        if (!peopleByNames.ContainsKey(name))
        {
            Person newPerson = new Person(name, null);
            peopleByNames.Add(name, newPerson);
            return newPerson;
        }

        return peopleByNames[name];
    }
}
