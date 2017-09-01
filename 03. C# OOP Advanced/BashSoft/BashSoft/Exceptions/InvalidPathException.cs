namespace BashSoft.Exceptions
{
    using System;

    public class InvalidPathException : Exception
    {
        public const string InvalidPath = "The source does not exist!";

        public InvalidPathException()
            : base(InvalidPath)
        {
        }

        public InvalidPathException(string message)
            : base(message)
        {
        }
    }
}