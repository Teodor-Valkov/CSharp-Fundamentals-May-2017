namespace _03.Ferrari.Contracts
{
    public interface ICar
    {
        string Model { get; }

        string Driver { get; }

        string HitBreak();

        string HitGas();
    }
}