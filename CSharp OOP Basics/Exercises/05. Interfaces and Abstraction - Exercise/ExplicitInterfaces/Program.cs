using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        List<Citizen> citizens = new List<Citizen>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            var split = input.Split();
            citizens.Add(new Citizen(split[0], split[1], int.Parse(split[2])));
        }

        foreach (var citizen in citizens)
        {
            Console.WriteLine(((IPerson)citizen).GetName());
            Console.WriteLine(((IResident)citizen).GetName());
        }
    }
}
