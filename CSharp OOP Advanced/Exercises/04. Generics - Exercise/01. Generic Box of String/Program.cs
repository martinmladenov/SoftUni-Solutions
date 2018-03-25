using System;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Box<string> box = new Box<string>(Console.ReadLine());

            Console.WriteLine(box.ToString());
        }
    }
}
