namespace _01.Logger.Models
{
    using Contracts;
    using Enums;

    public abstract class Layout : ILayout
    {
        public abstract string FormatMessage(ReportLevel reportLevel, string date, string message);
    }
}