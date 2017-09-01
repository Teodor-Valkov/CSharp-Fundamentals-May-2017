using System.Collections.Generic;

public delegate void AttackKingEventHandler(object sender, AttackKingEventArgs args);

public class King
{
    public King(string name)
    {
        this.Name = name;
    }

    public event AttackKingEventHandler AttackKingEvent;

    public string Name { get; private set; }

    public void AttackKing(List<ISoldier> soldiers)
    {
        foreach (Soldier soldier in soldiers)
        {
            this.OnAttackKing(new AttackKingEventArgs(soldier));
        }
    }

    public void OnAttackKing(AttackKingEventArgs eventArgs)
    {
        if (AttackKingEvent != null)
        {
            this.AttackKingEvent(this, eventArgs);
        }
    }
}