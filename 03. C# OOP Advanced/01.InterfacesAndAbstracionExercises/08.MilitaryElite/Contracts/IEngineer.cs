namespace _08.MilitaryElite.Contracts
{
    using System.Collections.Generic;

    public interface IEngineer : ISpecialisedSoldier
    {
        IList<IPart> Parts { get; }
    }
}