using System;
using System.Collections.Generic;

public class King : IKing
{
    public event EventHandler BeingAttacked;

    private IDictionary<string, ISoldier> soldiers;

    public King(string name)
    {
        this.Name = name;
        this.soldiers = new Dictionary<string, ISoldier>();
    }

    public string Name { get; }

    public void AddUnit(ISoldier soldier)
    {
        if (!this.soldiers.ContainsKey(soldier.Name))
        {
            this.BeingAttacked += soldier.Defend;
            soldier.Die += this.KillUnit;

            this.soldiers[soldier.Name] = soldier;
        }
    }

    private void KillUnit(object obj, EventArgs args)
    {
        ISoldier soldier = (ISoldier)obj;

        if (this.soldiers.ContainsKey(soldier.Name))
        {
            this.soldiers.Remove(soldier.Name);

            soldier.Die -= this.KillUnit;
            this.BeingAttacked -= soldier.Defend;
        }
    }

    public void OnBeingAttacked()
    {
        Console.WriteLine($"King {this.Name} is under attack!");

        if (this.BeingAttacked != null)
        {
            this.BeingAttacked.Invoke(this, EventArgs.Empty);
        }
    }

    public void AttackSoldier(string soldierName)
    {
        if (this.soldiers.ContainsKey(soldierName))
        {
            this.soldiers[soldierName].TakeDamage();
        }
    }
}