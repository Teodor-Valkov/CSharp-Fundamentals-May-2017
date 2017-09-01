using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        string firstPlayer = Console.ReadLine();
        string secondPlayer = Console.ReadLine();

        IList<Card> firstPlayerCards = new List<Card>();
        IList<Card> secondPlayerCards = new List<Card>();

        while (true)
        {
            string[] cardArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string rankAsString = cardArgs[0];
            string suitAsString = cardArgs[2];

            Rank rank;
            Suit suit;

            try
            {
                rank = (Rank)Enum.Parse(typeof(Rank), rankAsString);
                suit = (Suit)Enum.Parse(typeof(Suit), suitAsString);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("No such card exists.");
                continue;
            }

            Card card = new Card(rank, suit);

            if (firstPlayerCards.Contains(card) || secondPlayerCards.Contains(card))
            {
                Console.WriteLine("Card is not in the deck.");
                continue;
            }

            if (firstPlayerCards.Count < 5)
            {
                firstPlayerCards.Add(card);
            }
            else
            {
                secondPlayerCards.Add(card);
            }

            if (secondPlayerCards.Count == 5)
            {
                break;
            }
        }

        int firstPlayerMaxCardPower = firstPlayerCards.Max(card => card.GetCardPower());
        int secondPlayerMaxCardPower = secondPlayerCards.Max(card => card.GetCardPower());

        if (firstPlayerMaxCardPower > secondPlayerMaxCardPower)
        {
            Console.WriteLine($"{firstPlayer} wins with {firstPlayerCards.First(card => card.GetCardPower() == firstPlayerMaxCardPower)}.");
        }
        else if (firstPlayerMaxCardPower < secondPlayerMaxCardPower)
        {
            Console.WriteLine($"{secondPlayer} wins with {secondPlayerCards.First(card => card.GetCardPower() == secondPlayerMaxCardPower)}.");
        }
        else
        {
            Console.WriteLine($"The max card power of each player is equal.");
        }
    }
}