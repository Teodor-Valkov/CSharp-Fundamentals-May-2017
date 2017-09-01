namespace _02.BlobFromSkeleton.Core.IO
{
    using Contracts.IO;
    using System;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}