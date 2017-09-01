using System;

public class InvalidSongException : Exception
{
    private new const string Message = "Invalid song.";

    public InvalidSongException()
        : base(Message)
    {
    }

    protected InvalidSongException(string message)
        : base(message)
    {
    }
}