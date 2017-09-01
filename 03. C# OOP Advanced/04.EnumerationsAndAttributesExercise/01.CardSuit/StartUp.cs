using System;

public class StartUp
{
    public static void Main()
    {
        Array suits = Enum.GetValues(typeof(Suit));

        Console.WriteLine("Card Suits:");
        foreach (Suit suit in suits)
        {
            Console.WriteLine($"Ordinal value: {(int)suit}; Name value: {suit}");
        }
    }
}