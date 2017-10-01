using System;

namespace _04.Tourist_Information
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            double amount = double.Parse(Console.ReadLine());
            double newAmount = 0;
            string newType = string.Empty;
            switch (type)
            {
                case "miles":
                    newAmount = amount * 1.6;
                    newType = "kilometers";
                    break;
                case "inches":
                    newAmount = amount * 2.54;
                    newType = "centimeters";
                    break;
                case "feet":
                    newAmount = amount * 30;
                    newType = "centimeters";
                    break;
                case "yards":
                    newAmount = amount * 0.91;
                    newType = "meters";
                    break;
                case "gallons":
                    newAmount = amount * 3.8;
                    newType = "liters";
                    break;
            }
            Console.WriteLine($"{amount} {type} = {newAmount:f2} {newType}");
        }
    }
}
