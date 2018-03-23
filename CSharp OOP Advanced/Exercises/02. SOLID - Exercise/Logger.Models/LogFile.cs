namespace Logger.Models
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Contracts;

    public class LogFile : ILogFile
    {
        private StringBuilder stringBuilder;

        public LogFile()
        {
            this.stringBuilder = new StringBuilder();
        }

        public void Write(string message)
        {
            stringBuilder.AppendLine(message);

            File.AppendAllText("log.txt", message + Environment.NewLine);
        }

        public int Size => this.stringBuilder.ToString()
            .Where(c => c >= 'a' && c <= 'z' ||
                        c >= 'A' && c <= 'Z')
            .Sum(c => c);
    }
}
