namespace _01.RecyclingStation.IO
{
    using _01.RecyclingStation.Contracts.IO;
    using System;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}