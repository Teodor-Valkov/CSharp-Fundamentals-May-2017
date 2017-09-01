using System;
using System.Text;

public class ConsoleWriter : IWriter
{
    private StringBuilder sb;

    public ConsoleWriter()
    {
        this.sb = new StringBuilder();
    }

    public string GetStoredMessage
    {
        get { return this.sb.ToString().Trim(); }
    }

    public void AppendLine(string message)
    {
        this.sb.AppendLine(message.Trim());
    }

    public void WriteLine(string output)
    {
        Console.WriteLine(output);
    }
}