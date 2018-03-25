using System;

public class Program
{
    public static void Main(string[] args)
    {
        string[] nameAddressTownStrings = Console.ReadLine().Split();
        var nameAddressTown = new Threeuple<string, string, string>(
            $"{nameAddressTownStrings[0]} {nameAddressTownStrings[1]}",
            nameAddressTownStrings[2],
            nameAddressTownStrings[3]);

        string[] nameBeerDrunkStrings = Console.ReadLine().Split();
        var nameBeerDrunk = new Threeuple<string, int, bool>(
            nameBeerDrunkStrings[0],
            int.Parse(nameBeerDrunkStrings[1]),
            nameBeerDrunkStrings[2] == "drunk");

        string[] nameBalanceBankStrings = Console.ReadLine().Split();
        var nameBalanceBank = new Threeuple<string, double, string>(
            nameBalanceBankStrings[0],
            double.Parse(nameBalanceBankStrings[1]),
            nameBalanceBankStrings[2]);

        Console.WriteLine(nameAddressTown);
        Console.WriteLine(nameBeerDrunk);
        Console.WriteLine(nameBalanceBank);
    }
}
