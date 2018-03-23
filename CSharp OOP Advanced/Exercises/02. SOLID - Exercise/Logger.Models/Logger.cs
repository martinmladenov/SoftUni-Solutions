namespace Logger.Models
{
    using System.Collections.Generic;
    using Contracts;

    public class Logger : ILogger
    {
        private IEnumerable<IAppender> appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        public void Info(string dateTime, string messageText)
        {
            this.Log(dateTime, messageText, ReportLevel.Info);
        }

        public void Warn(string dateTime, string messageText)
        {
            this.Log(dateTime, messageText, ReportLevel.Warning);
        }

        public void Error(string dateTime, string messageText)
        {
            this.Log(dateTime, messageText, ReportLevel.Error);
        }

        public void Critical(string dateTime, string messageText)
        {
            this.Log(dateTime, messageText, ReportLevel.Critical);
        }

        public void Fatal(string dateTime, string messageText)
        {
            this.Log(dateTime, messageText, ReportLevel.Fatal);
        }

        private void Log(string dateTime, string messageText, ReportLevel reportLevel)
        {
            IMessage message = new Message(dateTime, reportLevel, messageText);

            foreach (var appender in appenders)
            {
                appender.Append(message);
            }
        }
    }
}
