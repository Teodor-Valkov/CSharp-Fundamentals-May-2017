using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main(string[] args)
    {
        List<Soldier> army = new List<Soldier>();
        King king = new King(Console.ReadLine());

        string[] royalGuards = Console.ReadLine().Split();
        foreach (string royalGuard in royalGuards)
        {
            RoyalGuard guard = new RoyalGuard(royalGuard);
            army.Add(guard);

            king.UnderAttack += guard.KingUnderAttack;
        }

        string[] footmen = Console.ReadLine().Split();
        foreach (string footman in footmen)
        {
            Footman foot = new Footman(footman);
            army.Add(foot);

            king.UnderAttack += foot.KingUnderAttack;
        }

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string action = inputArgs[0];
            string name = inputArgs[1];

            switch (action)
            {
                case "Kill":
                    Soldier soldier = army.FirstOrDefault(s => s.Name == name);
                    king.UnderAttack -= soldier.KingUnderAttack;
                    army.Remove(soldier);
                    break;

                case "Attack":
                    king.OnUnderAttack();
                    break;
            }
        }
    }
}