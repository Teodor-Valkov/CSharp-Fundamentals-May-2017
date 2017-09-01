namespace _03.NumberWars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            Queue<string> firstPlayerCards = new Queue<string>(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            Queue<string> secondPlayerCards = new Queue<string>(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

            string winner = string.Empty;
            bool lostAllCards = false;
            int rounds = 0;

            for (int i = 1; i <= 1000000; i++)
            {
                rounds = i;

                // First player draws a card
                string firstPlayerCard = firstPlayerCards.Dequeue();
                long firstPlayerNumber = long.Parse(firstPlayerCard.Substring(0, firstPlayerCard.Length - 1));

                // Second player draws a card
                string secondPlayerCard = secondPlayerCards.Dequeue();
                long secondPlayerNumber = long.Parse(secondPlayerCard.Substring(0, secondPlayerCard.Length - 1));

                // First player wins and gets the cards in descending order
                if (firstPlayerNumber > secondPlayerNumber)
                {
                    firstPlayerCards.Enqueue(firstPlayerCard);
                    firstPlayerCards.Enqueue(secondPlayerCard);
                }
                // Second player wins and gets the cards in descending order
                else if (firstPlayerNumber < secondPlayerNumber)
                {
                    secondPlayerCards.Enqueue(secondPlayerCard);
                    secondPlayerCards.Enqueue(firstPlayerCard);
                }
                // Tie
                else
                {
                    List<string> cards = new List<string>();

                    // Add the cards to the winner's hand
                    cards.Add(firstPlayerCard);
                    cards.Add(secondPlayerCard);

                    bool turnEnded = false;

                    while (!turnEnded)
                    {
                        // The players have less than 3 cards
                        if (firstPlayerCards.Count < 3 && secondPlayerCards.Count < 3)
                        {
                            lostAllCards = true;
                            break;
                        }

                        // Second player has less than 3 cards and the first player is the winner
                        if (secondPlayerCards.Count < 3 && firstPlayerCards.Count >= 3)
                        {
                            winner = "First";
                            lostAllCards = true;
                            break;
                        }

                        // First player has less than 3 cards and the second player is the winner
                        if (firstPlayerCards.Count < 3 && secondPlayerCards.Count >= 3)
                        {
                            winner = "Second";
                            lostAllCards = true;
                            break;
                        }

                        // First player draw 3 cards
                        string first1 = firstPlayerCards.Dequeue();
                        string first2 = firstPlayerCards.Dequeue();
                        string first3 = firstPlayerCards.Dequeue();

                        // Second player draw 3 cards
                        string second1 = secondPlayerCards.Dequeue();
                        string second2 = secondPlayerCards.Dequeue();
                        string second3 = secondPlayerCards.Dequeue();

                        // Calculate first player current hand and second player current hand
                        int firstPlayerSum = GetLetterSum(first1) + GetLetterSum(first2) + GetLetterSum(first3);
                        int secondPlayerSum = GetLetterSum(second1) + GetLetterSum(second2) + GetLetterSum(second3);

                        // Add the cards to the winner's hand
                        cards.AddRange(new[] { first1, first2, first3, second1, second2, second3 });

                        // Tie
                        if (firstPlayerSum == secondPlayerSum)
                        {
                            continue;
                        }

                        // First player wins and gets the cards in descending order
                        if (firstPlayerSum > secondPlayerSum)
                        {
                            cards = cards
                               .OrderByDescending(card => int.Parse(card.Substring(0, card.Length - 1)))
                               .ThenByDescending(card => card.Last())
                               .ToList();

                            foreach (string card in cards)
                            {
                                firstPlayerCards.Enqueue(card);
                            }

                            turnEnded = true;
                        }
                        // Second player wins and gets the cards in descending order
                        else if (firstPlayerSum < secondPlayerSum)
                        {
                            cards = cards
                                .OrderByDescending(card => int.Parse(card.Substring(0, card.Length - 1)))
                                .ThenByDescending(card => card.Last())
                                .ToList();

                            foreach (string card in cards)
                            {
                                secondPlayerCards.Enqueue(card);
                            }

                            turnEnded = true;
                        }
                    }
                }

                // Break if one or two of the players has less than 3 cards
                if (lostAllCards)
                {
                    break;
                }

                // First player is the winner if the second player has 0 cards
                if (secondPlayerCards.Count == 0)
                {
                    winner = "First";
                    break;
                }

                // Second player is the winner if the first player has 0 cards
                if (firstPlayerCards.Count == 0)
                {
                    winner = "Second";
                    break;
                }
            }

            // Find the winner if some of the players has less than 3 cards
            if (lostAllCards)
            {
                if (firstPlayerCards.Count > secondPlayerCards.Count)
                {
                    winner = "First";
                }
                else if (firstPlayerCards.Count < secondPlayerCards.Count)
                {
                    winner = "Second";
                }
            }
            // Find the winner if the game was 1000000 rounds
            else if (rounds == 1000000)
            {
                if (firstPlayerCards.Count > secondPlayerCards.Count)
                {
                    winner = "First";
                }
                else if (firstPlayerCards.Count < secondPlayerCards.Count)
                {
                    winner = "Second";
                }
            }

            Console.WriteLine(string.IsNullOrEmpty(winner)
                ? $"Draw after {rounds} turns"
                : $"{winner} player wins after {rounds} turns");
        }

        // Find given card letter sum
        private static int GetLetterSum(string card)
        {
            return card[card.Length - 1];
        }
    }
}