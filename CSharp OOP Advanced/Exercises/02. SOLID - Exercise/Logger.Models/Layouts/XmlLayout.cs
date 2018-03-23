namespace Logger.Models.Layouts
{
    using System;
    using Contracts;

    public class XmlLayout : ILayout
    {
        private readonly string messageFormat = "<log>" + Environment.NewLine +
                                                    "\t<date>{0}</date>" + Environment.NewLine +
                                                    "\t<level>{1}</level>" + Environment.NewLine +
                                                    "\t<message>{2}</message>" + Environment.NewLine +
                                                "</log>";

        public string FormatMessage(IMessage message)
        {
            return string.Format(messageFormat,
                message.DateTime,
                message.ReportLevel.ToString().ToUpper(),
                message.MessageText);
        }
    }
}
