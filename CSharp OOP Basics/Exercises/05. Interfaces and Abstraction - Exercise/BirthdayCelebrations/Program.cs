using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<IBirthable> list = new List<IBirthable>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            var data = input.Split();

            IBirthable toAdd = null;

            if (data[0] == "Citizen")
            {
                toAdd = new Citizen(data[1], int.Parse(data[2]), data[4]);
            }
            else if (data[0] == "Pet")
            {
                toAdd = new Pet(data[1], data[2]);
            }
            else
            {
                continue;
            }

            list.Add(toAdd);
        }

        string ending = Console.ReadLine();

        foreach (var birthable in list.Where(b => b.Birthdate.Split('/').Last() == ending))
        {
            Console.WriteLine(birthable.Birthdate);
        }
    }
}


