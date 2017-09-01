namespace _01.LoggerFromSkeleton.Models.Appenders
{
    using Contracts;
    using Enums;
    using System.Text;

    public abstract class Appender : IAppender
    {
        protected Appender(ILayout layout)
        {
            this.Layout = layout;
        }

        public int Count { get; protected set; }

        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }

        public abstract void Append(string time, string reportLevel, string message);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Appender type: {this.GetType().Name}, ")
              .Append($"Layout type: {this.Layout.GetType().Name}, ")
              .Append($"Report level: {this.ReportLevel.ToString().ToUpper()}, ")
              .Append($"Message appended: {this.Count}");

            return sb.ToString().Trim();
        }
    }
}