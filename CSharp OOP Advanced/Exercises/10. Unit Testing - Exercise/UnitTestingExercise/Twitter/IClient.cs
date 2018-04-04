namespace UnitTestingExercise.Twitter
{
    public interface IClient
    {
        void SendToServer(string msg);
        void WriteToConsole(string msg);
    }
}