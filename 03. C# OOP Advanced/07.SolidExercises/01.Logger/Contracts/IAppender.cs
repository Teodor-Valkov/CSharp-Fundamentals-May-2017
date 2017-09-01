namespace _01.Logger.Contracts
{
    public interface IAppender
    {
        void Append(string message);
    }
}