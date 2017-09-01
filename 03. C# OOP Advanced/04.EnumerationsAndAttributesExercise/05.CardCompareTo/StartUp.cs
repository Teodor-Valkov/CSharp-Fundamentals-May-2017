using System;

public class StartUp
{
    public static void Main()
    {
        string firstRankAsString = Console.ReadLine();
        string firstSuitAsString = Console.ReadLine();
        string secondRankAsString = Console.ReadLine();
        string secondSuitAsString = Console.ReadLine();

        Rank firstRank;
        Suit firstSuit;

        Enum.TryParse(firstRankAsString, out firstRank);
        Enum.TryParse(firstSuitAsString, out firstSuit);

        Rank secondRank = (Rank)Enum.Parse(typeof(Rank), secondRankAsString);
        Suit secondSuit = (Suit)Enum.Parse(typeof(Suit), secondSuitAsString);

        Card firstCard = new Card(firstRank, firstSuit);
        Card secondCard = new Card(secondRank, secondSuit);

        Console.WriteLine(firstCard.CompareTo(secondCard) > 0
           ? firstCard
           : secondCard);
    }
}