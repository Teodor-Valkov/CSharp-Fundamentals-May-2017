using System;
using System.Text;

public class ConsoleWriter : IOutputWriter
{
    public ConsoleWriter(StringBuilder sb)
    {
        this.Sb = sb;
    }

    public ConsoleWriter()
       : this(new StringBuilder())
    {
    }

    public StringBuilder Sb { get; private set; }

    public void WriteLine(string output)
    {
        this.Sb.AppendLine(output);
    }

    public void WriteAllLines()
    {
        Console.WriteLine(Sb.ToString().Trim());
    }
}