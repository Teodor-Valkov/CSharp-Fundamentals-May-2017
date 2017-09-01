namespace _02.Blob.IO
{
    using System;

    public class ConsoleWriter : IWriter
    {
        public void Writer(string output)
        {
            Console.WriteLine(output);
        }
    }
}