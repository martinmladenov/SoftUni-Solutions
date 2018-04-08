namespace P01_EventImplementation
{
    using System;

    public class Program
    {
        public static void Main()
        {
            Dispatcher dispatcher = new Dispatcher(null);
            Handler handler = new Handler();

            dispatcher.NameChange += handler.OnDispatcherNameChange;

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                dispatcher.Name = input;
            }
        }
    }
}
