using System;
// ReSharper disable CheckNamespace

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Family family = new Family();

        for (int i = 0; i < n; i++)
        {
            string[] split = Console.ReadLine().Split();
            string name = split[0];
            int age = int.Parse(split[1]);
            family.AddMember(new Person(name, age));
        }

        Console.WriteLine(family.GetOldestMember());
    }
}
