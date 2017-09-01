using System;

public class StartUp
{
    public static void Main()
    {
        Array ranks = Enum.GetValues(typeof(Rank));

        Console.WriteLine("Card Ranks:");
        foreach (Rank rank in ranks)
        {
            Console.WriteLine($"Ordinal value: {(int)rank}; Name value: {rank}");
        }
    }
}