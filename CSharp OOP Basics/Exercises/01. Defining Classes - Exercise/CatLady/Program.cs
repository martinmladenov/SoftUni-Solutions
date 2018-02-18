using System;
using System.Collections.Generic;

// ReSharper disable CheckNamespace

public class Program
{
    public static void Main()
    {
        var cats = new Dictionary<string, Cat>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            var split = input.Split();

            string type = split[0];
            string name = split[1];
            string data = split[2];

            if (type == "Siamese")
            {
                cats[name] = new SiameseCat(name, int.Parse(data));
            }
            else if (type == "Cymric")
            {
                cats[name] = new CymricCat(name, double.Parse(data));
            }
            else if (type == "StreetExtraordinaire")
            {
                cats[name] = new StreetExtraordinaireCat(name, int.Parse(data));
            }
        }

        string nameToPrint = Console.ReadLine();

        Console.WriteLine(cats[nameToPrint]);
    }
}
