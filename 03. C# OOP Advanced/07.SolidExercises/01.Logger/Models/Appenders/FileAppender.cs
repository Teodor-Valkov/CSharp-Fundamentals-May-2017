namespace _01.Logger.Appenders
{
    using Contracts;
    using Enums;
    using System.IO;
    using System.Linq;

    public class FileAppender : Appender
    {
        private const string FilePath = "log.txt";

        public FileAppender(ILayout layout, ReportLevel reportLevel)
            : base(layout, reportLevel)
        {
            this.Writer = new StreamWriter(FilePath);
        }

        public StreamWriter Writer { get; private set; }

        public int TotalMessagesSize { get; private set; }

        protected override void ProcessMessage(string message)
        {
            this.TotalMessagesSize += message.Where(s => char.IsLower(s) || char.IsUpper(s)).Sum(s => s);
            this.Writer.WriteLine(message);
            this.Writer.Flush();
        }

        public override string ToString()
        {
            return $"{base.ToString()}, File size: {this.TotalMessagesSize}";
        }
    }
}