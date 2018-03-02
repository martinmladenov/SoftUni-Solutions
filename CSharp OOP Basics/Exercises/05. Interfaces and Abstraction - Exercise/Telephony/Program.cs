using System;

public class Program
{
    public static void Main()
    {
        Smartphone smartphone = new Smartphone();

        string[] numbers = Console.ReadLine().Split();
        foreach (var number in numbers)
        {   
            try
            {
                smartphone.CallNumber(number);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        string[] urls = Console.ReadLine().Split();
        foreach (var url in urls)
        {
            try
            {
                smartphone.BrowseWebsite(url);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }


    }
}
