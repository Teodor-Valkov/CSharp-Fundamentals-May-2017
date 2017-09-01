public class Tuple<TFirst, TSecond>
{
    public Tuple(TFirst firstItem, TSecond secondItem)
    {
        this.FirstItem = firstItem;
        this.SecondItem = secondItem;
    }

    public TFirst FirstItem { get; private set; }

    public TSecond SecondItem { get; private set; }

    public override string ToString()
    {
        return this.FirstItem + " -> " + this.SecondItem;
    }
}