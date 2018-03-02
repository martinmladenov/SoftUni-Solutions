using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        List<IIdetifiable> list = new List<IIdetifiable>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            var data = input.Split();

            IIdetifiable toAdd = null;

            if (data.Length == 3)
            {
                toAdd = new Citizen(data[0], int.Parse(data[1]), data[2]);
            }
            else if (data.Length == 2)
            {
                toAdd = new Robot(data[0], data[1]);
            }

            list.Add(toAdd);
        }

        string ending = Console.ReadLine();

        foreach (var idetifiable in list.FindAll(i => i.Id.EndsWith(ending)))
        {
            Console.WriteLine(idetifiable.Id);
        }
    }
}


