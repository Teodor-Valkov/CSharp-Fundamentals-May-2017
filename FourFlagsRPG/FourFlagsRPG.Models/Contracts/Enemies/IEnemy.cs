namespace FourFlagsRPG.Models.Contracts.Enemies
{
    using FourFlagsRPG.Models.Contracts.Beings;

    public interface IEnemy : IBeing
    {
        int Id { get; }
    }
}