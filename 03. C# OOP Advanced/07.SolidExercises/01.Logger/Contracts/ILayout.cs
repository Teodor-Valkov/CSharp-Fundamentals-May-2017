namespace _01.Logger.Contracts
{
    using Enums;

    public interface ILayout
    {
        string FormatMessage(ReportLevel level, string date, string message);
    }
}