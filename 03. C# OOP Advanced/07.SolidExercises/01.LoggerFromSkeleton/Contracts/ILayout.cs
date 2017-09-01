namespace _01.LoggerFromSkeleton.Contracts
{
    public interface ILayout
    {
        string FormatMessage(string time, string reportLevel, string message);
    }
}