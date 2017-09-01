public class Threeuple<TFirst, TSecond, TThird> : IThreeuple<TFirst, TSecond, TThird>
{
    public Threeuple(TFirst firstItem, TSecond secondItem, TThird thirdItem)
    {
        this.FirstItem = firstItem;
        this.SecondItem = secondItem;
        this.ThirdItem = thirdItem;
    }

    public TFirst FirstItem { get; private set; }

    public TSecond SecondItem { get; private set; }

    public TThird ThirdItem { get; private set; }
}