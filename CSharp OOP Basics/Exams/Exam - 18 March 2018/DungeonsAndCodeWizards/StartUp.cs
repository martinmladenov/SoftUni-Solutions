namespace DungeonsAndCodeWizards
{
    using System;

    public class StartUp
    {
        // DO NOT rename this file's namespace or class name.
        // However, you ARE allowed to use your own namespaces (or no namespaces at all if you prefer) in other classes.
        public static void Main(string[] args)
        {
            Engine engine = new Engine(new DungeonMaster());

            string input;
            while (!engine.IsGameOver() && !string.IsNullOrEmpty(input = Console.ReadLine()))
            {
                string output = engine.ProcessCommand(input.Split());

                if (!string.IsNullOrEmpty(output))
                {
                    Console.WriteLine(output);
                }
            }

            Console.WriteLine("Final stats:");
            Console.WriteLine(engine.GetStats());
        }
    }
}