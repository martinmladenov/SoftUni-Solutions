namespace Logger.Models.Layouts
{
    using Contracts;

    public class SimpleLayout : ILayout
    {
        private const string MessageFormat = "{0} - {1} - {2}";

        public string FormatMessage(IMessage message)
        {
            return string.Format(MessageFormat,
                message.DateTime,
                message.ReportLevel,
                message.MessageText);
        }
    }
}
