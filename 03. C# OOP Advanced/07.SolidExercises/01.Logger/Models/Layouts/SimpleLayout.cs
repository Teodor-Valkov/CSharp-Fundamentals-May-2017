namespace _01.Logger.Models.Layouts
{
    using Enums;

    public class SimpleLayout : Layout
    {
        public override string FormatMessage(ReportLevel reportLevel, string date, string message)
        {
            return $"{date} - {reportLevel.ToString().ToUpper()} - {message}";
        }
    }
}