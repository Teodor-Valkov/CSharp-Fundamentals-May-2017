namespace _01.LoggerFromSkeleton.Models.Appenders
{
    using Contracts;
    using System;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }

        public override void Append(string time, string reportLevel, string message)
        {
            this.Count++;
            Console.WriteLine(this.Layout.FormatMessage(time, reportLevel, message));
        }
    }
}