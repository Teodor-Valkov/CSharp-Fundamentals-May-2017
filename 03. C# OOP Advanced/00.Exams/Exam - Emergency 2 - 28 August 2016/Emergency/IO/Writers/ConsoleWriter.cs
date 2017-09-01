namespace Emergency.IO.Writers
{
    using Contracts.IO;
    using System;

    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}