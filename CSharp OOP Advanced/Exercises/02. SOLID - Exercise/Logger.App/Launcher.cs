namespace Logger.App
{
    using System;

    public class Launcher
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Engine engine = new Engine();

            for (int i = 0; i < n; i++)
            {
                engine.RegisterAppender(Console.ReadLine());
            }

            engine.InitializeLogger();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                engine.RecordMessage(input);
            }

            Console.WriteLine("Logger info");

            engine.PrintLoggerInfo();
        }
    }
}
