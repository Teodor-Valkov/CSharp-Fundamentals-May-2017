namespace _08.MilitaryElite.Contracts
{
    using System.Collections.Generic;

    public interface ICommando : ISpecialisedSoldier
    {
        IList<IMission> Missions { get; }
    }
}