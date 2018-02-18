// ReSharper disable CheckNamespace

using System;
using System.Collections.Generic;

public class Person
{
    public Company Company { get; set; }
    public List<Pokemon> Pokemon { get; }
    public List<Parent> Parents { get; }
    public List<Child> Children { get; }
    public Car Car { get; set; }

    public Person()
    {
        Pokemon = new List<Pokemon>();
        Parents = new List<Parent>();
        Children = new List<Child>();
    }

    public void PrintInformation()
    {
        Console.WriteLine("Company:");
        if (Company != null)
        {
            Console.WriteLine($"{Company.Name} {Company.Department} {Company.Salary:f2}");
        }

        Console.WriteLine("Car:");
        if (Car != null)
        {
            Console.WriteLine($"{Car.Model} {Car.Speed}");
        }

        Console.WriteLine("Pokemon:");
        foreach (var pokemon in Pokemon)
        {
            Console.WriteLine($"{pokemon.Name} {pokemon.Element}");
        }

        Console.WriteLine("Parents:");
        foreach (var parent in Parents)
        {
            Console.WriteLine($"{parent.Name} {parent.BirthDate}");
        }

        Console.WriteLine("Children:");
        foreach (var child in Children)
        {
            Console.WriteLine($"{child.Name} {child.BirthDate}");
        }
    }
}
