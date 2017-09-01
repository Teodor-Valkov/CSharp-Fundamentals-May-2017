using System.Collections.Generic;
using System.Text;

internal class UnitRepository : IRepository
{
    private IDictionary<string, int> amountOfUnits;

    public UnitRepository()
    {
        this.amountOfUnits = new SortedDictionary<string, int>();
    }

    public void AddUnit(IUnit unit)
    {
        string unitType = unit.GetType().Name;

        if (!this.amountOfUnits.ContainsKey(unitType))
        {
            this.amountOfUnits[unitType] = 0;
        }

        this.amountOfUnits[unitType]++;
    }

    public string RemoveUnit(string unitType)
    {
        if (!this.amountOfUnits.ContainsKey(unitType) || this.amountOfUnits[unitType] == 0)
        {
            return $"No such units in repository.";
        }

        this.amountOfUnits[unitType]--;
        return $"{unitType} retired!";
    }

    public string GetStatistics()
    {
        StringBuilder sb = new StringBuilder();

        foreach (KeyValuePair<string, int> unit in amountOfUnits)
        {
            sb.AppendLine($"{unit.Key} -> {unit.Value}");
        }

        return sb.ToString().Trim();
    }
}