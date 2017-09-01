public interface ITuple<TFirst, TSecond>
{
    TFirst FirstItem { get; }
    TSecond SecondItem { get; }
}