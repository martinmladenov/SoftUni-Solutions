namespace Logger.Models.Contracts
{
    public interface ILogger
    {
        void Critical(string dateTime, string message);
        void Error(string dateTime, string message);
        void Fatal(string dateTime, string messageText);
        void Info(string dateTime, string message);
        void Warn(string dateTime, string message);
    }
}