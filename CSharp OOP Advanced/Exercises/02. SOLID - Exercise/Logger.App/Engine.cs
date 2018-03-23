namespace Logger.App
{
    using System;
    using System.Collections.Generic;
    using Models;
    using Models.Appenders;
    using Models.Contracts;
    using Models.Layouts;

    public class Engine
    {
        private Logger logger;

        private List<IAppender> appenders;

        public Engine()
        {
            appenders = new List<IAppender>();
        }

        public void RegisterAppender(string line)
        {
            string[] split = line.Split();

            ILayout layout = null;

            if (split[1] == "SimpleLayout")
            {
                layout = new SimpleLayout();
            }
            else if (split[1] == "XmlLayout")
            {
                layout = new XmlLayout();
            }

            IAppender appender = null;

            if (split[0] == "ConsoleAppender")
            {
                appender = new ConsoleAppender(layout);
            }
            else if (split[0] == "FileAppender")
            {
                appender = new FileAppender(layout, ReportLevel.Info, new LogFile());
            }

            if (split.Length >= 3)
            {
                appender.ReportLevel = Enum.Parse<ReportLevel>(split[2], true);
            }

            appenders.Add(appender);
        }

        public void InitializeLogger()
        {
            logger = new Logger(appenders.ToArray());
        }

        public void RecordMessage(string line)
        {
            string[] split = line.Split('|');

            string errorLevel = split[0].ToLower();
            string dateTime = split[1];
            string messageText = split[2];

            if (errorLevel == "info")
            {
                logger.Info(dateTime, messageText);
            }
            else if (errorLevel == "warning")
            {
                logger.Warn(dateTime, messageText);
            }
            else if (errorLevel == "error")
            {
                logger.Error(dateTime, messageText);
            }
            else if (errorLevel == "critical")
            {
                logger.Critical(dateTime, messageText);
            }
            else if (errorLevel == "fatal")
            {
                logger.Fatal(dateTime, messageText);
            }
        }

        public void PrintLoggerInfo()
        {
            foreach (var appender in appenders)
            {

                Console.WriteLine($"Appender type: {appender.GetType().Name}, " +
                                  $"Layout type: {appender.Layout.GetType().Name}, " +
                                  $"Report level: {appender.ReportLevel}, " +
                                  $"Messages appended: {appender.MessagesAppended}" +
                                  (appender is FileAppender fileAppender
                                        ? $", File size: {fileAppender.File.Size}"
                                        : string.Empty));
            }
        }
    }
}
