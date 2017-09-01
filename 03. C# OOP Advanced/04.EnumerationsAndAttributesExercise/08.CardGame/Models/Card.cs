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

    public override bool Equals(object otherObject)
    {
        Card otherCard = otherObject as Card;

        if (otherCard == null)
        {
            return false;
        }

        return this.Rank.Equals(otherCard.Rank) && this.Suit.Equals(otherCard.Suit);
    }

    public override int GetHashCode()
    {
        int hash = 13;

        hash = (hash * 7) + this.Rank.GetHashCode();
        hash = (hash * 7) + this.Suit.GetHashCode();

        return hash;
    }

    public override string ToString()
    {
        return $"{this.Rank} of {this.Suit}";
    }
}