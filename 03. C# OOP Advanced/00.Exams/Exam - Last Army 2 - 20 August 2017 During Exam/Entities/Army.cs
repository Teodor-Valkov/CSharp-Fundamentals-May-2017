using System.Collections.Generic;
using System.Linq;

public class Army : IArmyy
{
    private Dictionary<string, List<ISoldier>> army;

    public Army()
    {
        this.Armyy = new Dictionary<string, List<ISoldier>>();
    }

    public IReadOnlyList<ISoldier> Soldiers
    {
        get
        {
            return this.Armyy.Values.SelectMany(s => s).ToList() as IReadOnlyList<ISoldier>;
        }
    }

    public Dictionary<string, List<ISoldier>> Armyy
    {
        get { return this.army; }
        private set { this.army = value; }
    }

    public void AddSoldier(ISoldier soldier)
    {
        string soldierType = soldier.GetType().Name;

        if (!this.army.ContainsKey(soldierType))
        {
            army[soldierType] = new List<ISoldier>();
        }

        this.army[soldierType].Add(soldier);
    }

    public void RegenerateTeam(string soldierType)
    {
        foreach (ISoldier soldier in this.army.Values.SelectMany(s => s).Where(s => s.GetType().Name == soldierType))
        {
            soldier.Regenerate();
        }
    }
}