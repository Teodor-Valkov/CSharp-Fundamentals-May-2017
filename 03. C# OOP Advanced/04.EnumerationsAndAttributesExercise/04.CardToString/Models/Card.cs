public class Card
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

    public override string ToString()
    {
        return $"Card name: {this.Rank} of {this.Suit}; Card power: {this.GetCardPower()}";
    }
}