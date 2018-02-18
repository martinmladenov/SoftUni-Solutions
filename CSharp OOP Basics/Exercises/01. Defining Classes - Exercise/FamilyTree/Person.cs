// ReSharper disable CheckNamespace

using System.Collections.Generic;

public class Person
{
    public string Name { get; set; }
    public List<Person> Parents { get; }
    public List<Person> Children { get; }
    public string Birthdate { get; set; }

    public Person(string name, string birthdate)
    {
        Name = name;
        Birthdate = birthdate;
        Parents = new List<Person>();
        Children = new List<Person>();
    }

    public void AddChild(Person child)
    {
        if (!Children.Contains(child))
        {
            Children.Add(child);
        }
    }

    public void AddParent(Person parent)
    {
        if (!Parents.Contains(parent))
        {
            Parents.Add(parent);
        }
    }

    public override string ToString()
    {
        return $"{Name} {Birthdate}";
    }
}
