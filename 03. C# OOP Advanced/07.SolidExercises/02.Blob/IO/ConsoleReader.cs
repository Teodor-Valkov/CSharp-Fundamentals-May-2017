namespace _02.Blob.IO
{
    using System;

    public class ConsoleReader : IReader
    {
        public string[] Read()
        {
            return Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}