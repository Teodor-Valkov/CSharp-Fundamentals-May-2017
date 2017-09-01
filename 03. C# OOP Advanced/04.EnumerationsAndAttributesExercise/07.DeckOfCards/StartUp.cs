using System;

public class StartUp
{
    public static void Main()
    {
        string deck = Console.ReadLine();

        Rank rankEnum;
        Suit suitEnum;

        for (int suit = 0; suit <= (int)Suit.Spades; suit++)
        {
            for (int rank = 0; rank <= (int)Rank.King; rank++)
            {
                Enum.TryParse(rank.ToString(), out rankEnum);
                Enum.TryParse(suit.ToString(), out suitEnum);

                Console.WriteLine($"{rankEnum} of {suitEnum}");
                //Console.WriteLine($"{Enum.Parse(typeof(Rank), rank.ToString())} of {Enum.Parse(typeof(Suit), suit.ToString())}");
            }
        }
    }
}