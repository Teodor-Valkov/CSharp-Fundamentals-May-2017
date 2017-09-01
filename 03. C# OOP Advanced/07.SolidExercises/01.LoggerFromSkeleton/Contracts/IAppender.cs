namespace _01.LoggerFromSkeleton.Contracts
{
    using Enums;

    public interface IAppender
    {
        int Count { get; }

        ILayout Layout { get; }

        ReportLevel ReportLevel { get; set; }

        void Append(string time, string reportLevel, string message);
    }
}