public interface IThreeuple<TFirst, TSecond, TThird>
{
    TFirst FirstItem { get; }

    TSecond SecondItem { get; }

    TThird ThirdItem { get; }
}