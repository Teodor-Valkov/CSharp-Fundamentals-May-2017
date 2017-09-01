namespace _01.Logger.Contracts
{
    public interface ILogger
    {
        void LogMessage(string message);

        void RegisterAppender(IAppender appender);
    }
}