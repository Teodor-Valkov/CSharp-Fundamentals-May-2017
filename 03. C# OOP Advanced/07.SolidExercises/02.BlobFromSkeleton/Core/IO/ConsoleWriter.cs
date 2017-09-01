namespace _02.BlobFromSkeleton.Core.IO
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