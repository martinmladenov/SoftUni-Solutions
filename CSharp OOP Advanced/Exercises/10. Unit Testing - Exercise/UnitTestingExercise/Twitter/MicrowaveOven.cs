namespace UnitTestingExercise.Twitter
{
    using System;

    public class MicrowaveOven : IClient
    {

        public void WriteToConsole(string msg)
        {
            Console.WriteLine(msg);
        }

        public void SendToServer(string msg)
        {
            
        }
    }

}
