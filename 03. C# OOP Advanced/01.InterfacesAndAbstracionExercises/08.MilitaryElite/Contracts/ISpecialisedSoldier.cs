namespace _08.MilitaryElite.Contracts
{
    public interface ISpecialisedSoldier : IPrivate
    {
        string Corps { get; }

        bool ValidateCorps();
    }
}