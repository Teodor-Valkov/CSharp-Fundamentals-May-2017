namespace _01.LoggerFromSkeleton.Models
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class LogFile
    {
        private const string DefaultFileName = "log.txt";

        private StringBuilder sb;

        public LogFile()
        {
            this.sb = new StringBuilder();
        }

        public int Size { get; private set; }

        public void Write(string message)
        {
            this.sb.AppendLine(message);
            this.Size += message.Where(s => char.IsLetter(s)).Sum(s => s);

            File.AppendAllText(DefaultFileName, message + Environment.NewLine);
        }
    }
}