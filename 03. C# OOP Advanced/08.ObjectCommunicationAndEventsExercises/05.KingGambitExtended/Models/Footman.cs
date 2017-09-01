using System;

public class Footman : Soldier
{
    private const int InitialHealth = 2;

    public Footman(string name)
        : base(name, InitialHealth)
    {
    }

    public override void Defend(object obj, EventArgs eventArgs)
    {
        Console.WriteLine($"Footman {this.Name} is panicking!");
    }
}