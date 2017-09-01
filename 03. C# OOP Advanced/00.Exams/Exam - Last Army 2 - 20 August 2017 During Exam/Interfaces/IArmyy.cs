using System.Collections.Generic;

public interface IArmyy : IArmy
{
    Dictionary<string, List<ISoldier>> Armyy { get; }
}