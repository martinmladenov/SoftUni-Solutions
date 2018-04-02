namespace InfernoInfinity
{
    using System;
    using Core;

    public class Program
    {
        public static void Main()
        {
            Engine engine = new Engine();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                engine.InterpretCommand(input);
            }
        }
    }
}
