using System;

public class Program
{
    public static void Main(string[] args)
    {
        Engine engine = new Engine();

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            engine.InterpretCommand(input);
        }
    }
}
