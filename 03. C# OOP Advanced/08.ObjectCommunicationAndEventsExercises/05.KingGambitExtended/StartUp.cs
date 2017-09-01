using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        string kingName = Console.ReadLine();
        IKing king = new King(kingName);

        IEnumerable<ISoldier> royalGuards = Console.ReadLine().Split().Select(rg => new RoyalGuard(rg));
        IEnumerable<ISoldier> footmens = Console.ReadLine().Split().Select(ft => new Footman(ft));

        foreach (ISoldier royalGuard in royalGuards)
        {
            king.AddUnit(royalGuard);
        }

        foreach (ISoldier footman in footmens)
        {
            king.AddUnit(footman);
        }

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string command = inputArgs[0];
            string soldierName = inputArgs[1];

            switch (command)
            {
                case "Kill":
                    king.AttackSoldier(soldierName);
                    break;

                case "Attack":
                    king.OnBeingAttacked();
                    break;
            }
        }
    }
}