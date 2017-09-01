namespace _01.LoggerFromSkeleton.Models.Appenders
{
    using Contracts;

    public class FileAppender : Appender
    {
        public FileAppender(ILayout layout)
            : base(layout)
        {
            this.File = new LogFile();
        }

        public LogFile File { get; private set; }

        public override void Append(string time, string reportLevel, string message)
        {
            this.Count++;
            this.File.Write(this.Layout.FormatMessage(time, reportLevel, message));
        }

        public override string ToString()
        {
            return base.ToString() + $", File size: {this.File.Size}";
        }
    }
}