using System;

public class Card : IComparable<Card>
{
    public Card(Rank rank, Suit suit)
    {
        this.Rank = rank;
        this.Suit = suit;
    }

    public Rank Rank { get; private set; }

    public Suit Suit { get; private set; }

    public int GetCardPower()
    {
        return (int)this.Rank + (int)this.Suit;
    }

    public int CompareTo(Card other)
    {
        return this.GetCardPower().CompareTo(other.GetCardPower());
    }

    public override string ToString()
    {
        return $"Card name: {this.Rank} of {this.Suit}; Card power: {this.GetCardPower()}";
    }
}