namespace _01.LoggerFromSkeleton.Models.Layouts
{
    using Contracts;

    public class SimpleLayout : ILayout
    {
        public string FormatMessage(string time, string reportLevel, string message)
        {
            return $"{time} - {reportLevel} - {message}";
        }
    }
}