using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var buyers = new Dictionary<string, IBuyer>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var split = Console.ReadLine().Split();

            IBuyer buyer = null;

            string name = split[0];
            int age = int.Parse(split[1]);

            if (split.Length == 4)
            {
                buyer = new Citizen(name, age, split[2], split[3]);
            }
            else if (split.Length == 3)
            {
                buyer = new Rebel(name, age, split[2]);
            }

            buyers.Add(name, buyer);
        }

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            if (!buyers.ContainsKey(input))
            {
                continue;
            }

            buyers[input].BuyFood();
        }

        Console.WriteLine(buyers.Values.Sum(b => b.Food));
    }
}
