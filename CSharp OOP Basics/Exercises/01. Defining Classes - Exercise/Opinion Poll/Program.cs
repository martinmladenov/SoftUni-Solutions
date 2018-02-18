using System;
using System.Linq;

// ReSharper disable CheckNamespace

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Person[] arr = new Person[n];

        for (int i = 0; i < n; i++)
        {
            string[] split = Console.ReadLine().Split();
            string name = split[0];
            int age = int.Parse(split[1]);
            arr[i] = new Person(name, age);
        }

        foreach (var person in arr.Where(p => p.Age > 30)
                                  .OrderBy(p => p.Name))
        {
            Console.WriteLine(person);
        }
    }
}
