namespace _01.LoggerFromSkeleton.Core.IO
{
    using Contracts;
    using System;

    public class Writer : IWriter
    {
        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }
    }
}