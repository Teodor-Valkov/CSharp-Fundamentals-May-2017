public interface IWriter
{
    string GetStoredMessage { get; }

    void WriteLine(string output);

    void AppendLine(string message);
}