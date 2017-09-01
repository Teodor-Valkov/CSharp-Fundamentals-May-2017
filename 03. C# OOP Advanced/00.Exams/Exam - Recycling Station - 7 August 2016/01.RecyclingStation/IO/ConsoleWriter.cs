namespace _01.RecyclingStation.IO
{
    using _01.RecyclingStation.Contracts.IO;
    using System;
    using System.Text;

    public class ConsoleWriter : IWriter
    {
        public ConsoleWriter()
            : this(new StringBuilder())
        {
        }

        public ConsoleWriter(StringBuilder sb)
        {
            this.Sb = sb;
        }

        public StringBuilder Sb { get; private set; }

        public void WriteAllLines()
        {
            Console.WriteLine(Sb.ToString().Trim());
        }

        public void WriteLine(string output)
        {
            this.Sb.AppendLine(output);
        }
    }
}