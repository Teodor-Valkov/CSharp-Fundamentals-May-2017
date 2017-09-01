using System;
using System.Linq;

public class Song
{
    private string artist;
    private string name;
    private int minutes;
    private int seconds;

    public Song(string artist, string name, string length)
    {
        this.Artist = artist;
        this.Name = name;
        this.SetLength(length);
    }

    public string Artist
    {
        get
        {
            return this.artist;
        }
        private set
        {
            if (value.Length < 3 || value.Length > 20)
            {
                throw new InvalidArtistNameException();
            }
            this.artist = value;
        }
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            if (value.Length < 3 || value.Length > 30)
            {
                throw new InvalidSongNameException();
            }
            this.name = value;
        }
    }

    public int Minutes
    {
        get
        {
            return this.minutes;
        }
        private set
        {
            if (value < 0 || value > 14)
            {
                throw new InvalidSongMinutesException();
            }
            this.minutes = value;
        }
    }

    public int Seconds
    {
        get
        {
            return this.seconds;
        }
        private set
        {
            if (value < 0 || value > 59)
            {
                throw new InvalidSongSecondsException();
            }
            this.seconds = value;
        }
    }

    private void SetLength(string length)
    {
        try
        {
            int[] lengthArgs = length.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int songMinutes = lengthArgs[0];
            int songSeconds = lengthArgs[1];

            this.Minutes = songMinutes;
            this.Seconds = songSeconds;
        }
        catch (FormatException)
        {
            throw new InvalidSongLengthException();
        }
    }
}