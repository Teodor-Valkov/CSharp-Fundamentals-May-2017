namespace _01.Logger.Appenders
{
    using Contracts;
    using Core;
    using Enums;
    using System;

    public abstract class Appender : IAppender
    {
        protected Appender(ILayout layout, ReportLevel reportLevel)
        {
            this.Layout = layout;
            this.ReportLevel = reportLevel;
        }

        public ILayout Layout { get; private set; }

        public ReportLevel ReportLevel { get; private set; }

        public int MessageCount { get; private set; }

        public void Append(string message)
        {
            this.ParseMessage(message);
        }

        protected void ParseMessage(string message)
        {
            string[] messageArgs = message.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            string reportLevelAsString = messageArgs[0];
            string date = messageArgs[1];
            string messageText = messageArgs[2];

            ReportLevel reportLevel = Services.ParseReportLevel(reportLevelAsString);
            if (reportLevel >= this.ReportLevel)
            {
                this.MessageCount++;
                this.ProcessMessage(this.Layout.FormatMessage(reportLevel, date, messageText));
            }
        }

        protected abstract void ProcessMessage(string message);

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel.ToString().ToUpper()}, Messages appended: {this.MessageCount}";
        }
    }
}