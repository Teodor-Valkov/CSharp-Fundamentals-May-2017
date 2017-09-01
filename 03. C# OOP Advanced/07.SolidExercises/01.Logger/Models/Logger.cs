namespace _01.Logger
{
    using Contracts;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Logger : ILogger
    {
        protected Logger()
        {
            this.Appenders = new List<IAppender>();
        }

        public List<IAppender> Appenders { get; private set; }

        public void LogMessage(string message)
        {
            foreach (IAppender appender in this.Appenders)
            {
                appender.Append(message);
            }
        }

        public void RegisterAppender(IAppender appender)
        {
            this.Appenders.Add(appender);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Logger info");

            foreach (IAppender appender in this.Appenders)
            {
                sb.AppendLine(appender.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}