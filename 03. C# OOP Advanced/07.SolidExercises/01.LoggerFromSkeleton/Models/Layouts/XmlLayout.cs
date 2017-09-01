namespace _01.LoggerFromSkeleton.Models.Layouts
{
    using Contracts;
    using System.Text;

    public class XmlLayout : ILayout
    {
        public string FormatMessage(string time, string reportLevel, string message)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"<log>")
              .AppendLine($"   <date>{time}</date>")
              .AppendLine($"   <level>{reportLevel}</level>")
              .AppendLine($"   <message>{message}</message>")
              .AppendLine($"</log>");

            return sb.ToString().Trim();
        }
    }
}