using System;

public class StartUp
{
    public static void Main()
    {
        string rankAsString = Console.ReadLine();
        string suitAsString = Console.ReadLine();

        Rank rank;
        Suit suit;

        Enum.TryParse(rankAsString, out rank);
        Enum.TryParse(suitAsString, out suit);

        //Rank rank = (Rank)Enum.Parse(typeof(Rank), rankAsString);
        //Suit suit = (Suit)Enum.Parse(typeof(Suit), suitAsString);

        Card card = new Card(rank, suit);

        Console.WriteLine(card);
    }
}