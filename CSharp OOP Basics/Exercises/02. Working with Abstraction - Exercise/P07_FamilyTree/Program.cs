using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_FamilyTree
{
    public class Program
    {
        public static void Main()
        {
            var familyTree = new List<Person>();
            string personInput = Console.ReadLine();
            Person mainPerson = new Person();

            if (IsBirthday(personInput))
            {
                mainPerson.Birthday = personInput;
            }
            else
            {
                mainPerson.Name = personInput;
            }

            familyTree.Add(mainPerson);

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(" - ");
                if (tokens.Length > 1)
                {
                    string firstPerson = tokens[0];
                    string secondPerson = tokens[1];

                    Person currentPerson;

                    if (IsBirthday(firstPerson))
                    {
                        currentPerson = familyTree.FirstOrDefault(p => p.Birthday == firstPerson);

                        if (currentPerson == null)
                        {
                            currentPerson = new Person { Birthday = firstPerson };
                            familyTree.Add(currentPerson);
                        }

                        SetChild(familyTree, currentPerson, secondPerson);
                    }
                    else
                    {
                        currentPerson = familyTree.FirstOrDefault(p => p.Name == firstPerson);

                        if (currentPerson == null)
                        {
                            currentPerson = new Person { Name = firstPerson };
                            familyTree.Add(currentPerson);
                        }

                        SetChild(familyTree, currentPerson, secondPerson);
                    }
                }
                else
                {
                    tokens = tokens[0].Split();
                    string name = $"{tokens[0]} {tokens[1]}";
                    string birthday = tokens[2];

                    var namePerson = familyTree.FirstOrDefault(p => p.Name == name);
                    var birthdayPerson = familyTree.FirstOrDefault(p => p.Birthday == birthday);

                    if (namePerson != null && birthdayPerson == null)
                    {
                        namePerson.Birthday = birthday;
                    }
                    else if (namePerson == null && birthdayPerson != null)
                    {
                        birthdayPerson.Name = name;
                    }
                    else if (namePerson == null && birthdayPerson == null)
                    {
                        familyTree.Add(new Person() { Name = name, Birthday = birthday });
                    }
                    else
                    {
                        namePerson.Birthday = birthday;

                        foreach (var parent in birthdayPerson.Parents)
                        {
                            parent.Children.Remove(birthdayPerson);
                            parent.Children.Add(namePerson);
                        }

                        foreach (var child in birthdayPerson.Children)
                        {
                            child.Parents.Remove(birthdayPerson);
                            child.Parents.Add(namePerson);
                        }

                        namePerson.Parents.AddRange(birthdayPerson.Parents);
                        namePerson.Parents = namePerson.Parents.Distinct().ToList();

                        namePerson.Children.AddRange(birthdayPerson.Children);
                        namePerson.Children = namePerson.Children.Distinct().ToList();

                        if (birthdayPerson == mainPerson)
                        {
                            mainPerson = namePerson;
                        }

                        familyTree.Remove(birthdayPerson);
                    }
                }
            }

            Console.WriteLine(mainPerson);
            Console.WriteLine("Parents:");
            foreach (var parent in mainPerson.Parents)
            {
                Console.WriteLine(parent);
            }
            Console.WriteLine("Children:");
            foreach (var child in mainPerson.Children)
            {
                Console.WriteLine(child);
            }
        }

        private static void SetChild(List<Person> familyTree, Person parentPerson, string child)
        {
            var childPerson = new Person();

            if (IsBirthday(child))
            {
                if (familyTree.All(p => p.Birthday != child))
                {
                    childPerson.Birthday = child;
                }
                else
                {
                    childPerson = familyTree.First(p => p.Birthday == child);
                }
            }
            else
            {
                if (familyTree.All(p => p.Name != child))
                {
                    childPerson.Name = child;
                }
                else
                {
                    childPerson = familyTree.First(p => p.Name == child);
                }
            }

            parentPerson.Children.Add(childPerson);
            childPerson.Parents.Add(parentPerson);
            familyTree.Add(childPerson);
        }

        private static bool IsBirthday(string input)
        {
            return char.IsDigit(input[0]);
        }
    }
}
