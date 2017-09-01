using System;

public class RoyalGuard : Soldier
{
    private const int InitialHealth = 3;

    public RoyalGuard(string name)
        : base(name, InitialHealth)
    {
    }

    public override void Defend(object obj, EventArgs eventArgs)
    {
        Console.WriteLine($"Royal Guard {this.Name} is defending!");
    }
}