namespace _01.Logger.Appenders
{
    using Contracts;
    using Enums;
    using System;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout, ReportLevel reportLevel)
            : base(layout, reportLevel)
        {
        }

        protected override void ProcessMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}