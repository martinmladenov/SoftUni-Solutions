using System;

public class Program
{
    public static void Main()
    {
        string driverName = Console.ReadLine();
        ICar ferrari = new Ferrari(new Driver(driverName));

        Console.WriteLine(ferrari);
    }
}

