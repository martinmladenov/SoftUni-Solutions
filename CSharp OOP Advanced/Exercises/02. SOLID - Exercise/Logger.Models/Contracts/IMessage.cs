namespace Logger.Models.Contracts
{
    public interface IMessage
    {
        string DateTime { get; }
        ReportLevel ReportLevel { get; }
        string MessageText { get; }
    }
}