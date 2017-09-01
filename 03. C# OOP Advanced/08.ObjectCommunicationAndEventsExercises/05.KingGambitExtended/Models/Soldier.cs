using System;

public abstract class Soldier : ISoldier
{
    protected Soldier(string name, int health)
    {
        this.Name = name;
        this.Health = health;
    }

    public event EventHandler Die;

    public string Name { get; private set; }

    public int Health { get; private set; }

    public void TakeDamage()
    {
        this.Health--;

        if (this.Health == 0)
        {
            this.Die(this, EventArgs.Empty);
        }
    }

    public abstract void Defend(object obj, EventArgs args);
}