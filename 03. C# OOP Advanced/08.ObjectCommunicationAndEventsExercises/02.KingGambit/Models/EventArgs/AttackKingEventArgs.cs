using System;

public class AttackKingEventArgs : EventArgs
{
    public AttackKingEventArgs(Soldier soldier)
    {
        this.Soldier = soldier;
    }

    public Soldier Soldier { get; private set; }
}