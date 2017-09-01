using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        List<Song> songs = new List<Song>();
        int allSseconds = 0;

        for (int i = 0; i < number; i++)
        {
            string[] inputArgs = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            string artistName = inputArgs[0];
            string songName = inputArgs[1];
            string lengthArgs = inputArgs[2];

            try
            {
                Song song = new Song(artistName, songName, lengthArgs);
                songs.Add(song);

                Console.WriteLine("Song added.");
            }
            catch (InvalidSongException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        allSseconds += songs.Sum(song => song.Minutes) * 60;
        allSseconds += songs.Sum(song => song.Seconds);

        TimeSpan ts = TimeSpan.FromSeconds(allSseconds);

        Console.WriteLine($"Songs added: {songs.Count}");
        Console.WriteLine($"Playlist length: {ts.Hours}h {ts.Minutes}m {ts.Seconds}s");
    }
}