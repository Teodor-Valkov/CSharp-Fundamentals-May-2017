using System;

public interface ISoldier
{
    event EventHandler Die;

    string Name { get; }

    int Health { get; }

    void Defend(object obj, EventArgs eventArgs);

    void TakeDamage();
}