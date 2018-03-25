using System;

public class Program
{
    public static void Main(string[] args)
    {
        string[] nameAndAddressStrings = Console.ReadLine().Split();
        var nameAndAddress = new Tuple<string, string>($"{nameAndAddressStrings[0]} {nameAndAddressStrings[1]}", nameAndAddressStrings[2]);

        string[] nameAndBeerStrings = Console.ReadLine().Split();
        var nameAndBeer = new Tuple<string, int>(nameAndBeerStrings[0], int.Parse(nameAndBeerStrings[1]));

        string[] intAndDoubleStrings = Console.ReadLine().Split();
        var intAndDouble = new Tuple<int, double>(int.Parse(intAndDoubleStrings[0]), double.Parse(intAndDoubleStrings[1]));

        Console.WriteLine(nameAndAddress);
        Console.WriteLine(nameAndBeer);
        Console.WriteLine(intAndDouble);
    }
}
