using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var people = new Dictionary<string, Person>();
        var products = new Dictionary<string, Product>();

        try
        {
            var peopleInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            foreach (var personData in peopleInput.Select(p => p.Split('=')))
            {
                string name = personData[0];
                decimal money = decimal.Parse(personData[1]);
                people[name] = new Person(name, money);
            }

            var productsInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            foreach (var productData in productsInput.Select(p => p.Split('=')))
            {
                string name = productData[0];
                decimal cost = decimal.Parse(productData[1]);
                products[name] = new Product(name, cost);
            }

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var line = input.Split();
                string personName = line[0];
                string productName = line[1];

                if (people[personName].BuyProduct(products[productName]))
                {
                    Console.WriteLine($"{personName} bought {productName}");
                }
                else
                {
                    Console.WriteLine($"{personName} can't afford {productName}");
                }
            }

            foreach (var person in people.Values)
            {
                Console.WriteLine(person);
            }

        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
