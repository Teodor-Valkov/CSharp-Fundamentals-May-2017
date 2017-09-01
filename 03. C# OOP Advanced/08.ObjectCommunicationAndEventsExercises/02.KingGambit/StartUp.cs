using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        Handler handler = new Handler();
        King king = new King(Console.ReadLine());
        List<ISoldier> soldiers = new List<ISoldier>();

        string[] royalGuardsNames = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string royalGuardName in royalGuardsNames)
        {
            soldiers.Add(new RoyalGuard(royalGuardName));
        }

        string[] footmenNames = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string footmanName in footmenNames)
        {
            soldiers.Add(new Footman(footmanName));
        }

        king.AttackKingEvent += handler.OnAttackKing;

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string action = inputArgs[0];
            string name = inputArgs[1];

            switch (action)
            {
                case "Kill":
                    if (soldiers.Any(s => s.Name == name))
                    {
                        soldiers.RemoveAll(s => s.Name == name);
                    }
                    else if (soldiers.Any(s => s.Name == name))
                    {
                        soldiers.RemoveAll(s => s.Name == name);
                    }
                    break;

                case "Attack":
                    Console.WriteLine($"King {king.Name} is under attack!");
                    king.AttackKing(soldiers);
                    break;
            }
        }
    }
}