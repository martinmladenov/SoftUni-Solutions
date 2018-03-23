namespace Logger.Models
{
    using Contracts;

    public class Message : IMessage
    {
        public Message(string dateTime, ReportLevel reportLevel, string messageText)
        {
            DateTime = dateTime;
            ReportLevel = reportLevel;
            MessageText = messageText;
        }

        public string DateTime { get; }
        public ReportLevel ReportLevel { get; }
        public string MessageText { get; }
    }
}
