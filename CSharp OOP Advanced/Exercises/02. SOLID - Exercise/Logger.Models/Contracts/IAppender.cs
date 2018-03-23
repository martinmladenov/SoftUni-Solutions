namespace Logger.Models.Contracts
{
    public interface IAppender
    {
        ReportLevel ReportLevel { get; set; }

        int MessagesAppended { get; }

        ILayout Layout { get; }

        void Append(IMessage message);
    }
}