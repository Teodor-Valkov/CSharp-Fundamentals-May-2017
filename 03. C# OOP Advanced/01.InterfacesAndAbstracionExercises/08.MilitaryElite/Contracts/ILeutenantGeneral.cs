namespace _08.MilitaryElite.Contracts
{
    using System.Collections.Generic;

    public interface ILeutenantGeneral : IPrivate
    {
        IList<ISoldier> Privates { get; }
    }
}