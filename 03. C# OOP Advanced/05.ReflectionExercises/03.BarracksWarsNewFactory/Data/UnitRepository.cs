using System;
using System.Collections.Generic;
using System.Text;

internal class UnitRepository : IRepository
{
    private IDictionary<string, int> amountOfUnits;

    public UnitRepository()
    {
        this.amountOfUnits = new SortedDictionary<string, int>();
    }

    public string Statistics
    {
        get
        {
            StringBuilder statsBuilder = new StringBuilder();

            foreach (KeyValuePair<string, int> unit in amountOfUnits)
            {
                statsBuilder.AppendLine($"{unit.Key} -> {unit.Value}");
            }

            return statsBuilder.ToString().Trim();
        }
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

    public void RemoveUnit(string unitType)
    {
        //TODO: implement for Problem 4
        throw new NotImplementedException();
    }
}