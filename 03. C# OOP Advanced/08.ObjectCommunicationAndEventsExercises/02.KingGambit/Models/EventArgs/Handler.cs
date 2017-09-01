using System;

public class Handler
{
    public void OnAttackKing(object sender, AttackKingEventArgs eventArgs)
    {
        switch (eventArgs.Soldier.GetType().Name)
        {
            case "Footman":
                Console.WriteLine($"Footman {eventArgs.Soldier.Name} is panicking!");
                break;

            case "RoyalGuard":
                Console.WriteLine($"Royal Guard {eventArgs.Soldier.Name} is defending!");
                break;
        }
    }
}