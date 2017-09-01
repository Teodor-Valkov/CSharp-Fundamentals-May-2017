namespace _01.Logger.Models.Layouts
{
    using Enums;
    using System.Text;

    public class XmlLayout : Layout
    {
        public override string FormatMessage(ReportLevel reportLevel, string date, string message)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<log>");
            sb.AppendLine($"    <date>{date}<date>");
            sb.AppendLine($"    <level>{reportLevel.ToString().ToUpper()}<level>");
            sb.AppendLine($"    <message>{message}<message>");
            sb.AppendLine("<log>");

            return sb.ToString().Trim();
        }
    }
}