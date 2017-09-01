namespace _01.LoggerFromSkeleton.Core.IO
{
    using Contracts;
    using System;

    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}