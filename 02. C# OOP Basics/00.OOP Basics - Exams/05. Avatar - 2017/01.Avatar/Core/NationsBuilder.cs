using System;
using System.Collections.Generic;
using System.Text;

public class NationsBuilder
{
    private Dictionary<string, Nation> nations;
    private StringBuilder issuedWars;
    private int issuedWarsCount;

    public NationsBuilder()
    {
        this.InitializeNations();
        this.issuedWars = new StringBuilder();
    }

    private void InitializeNations()
    {
        this.nations = new Dictionary<string, Nation>
        {
            { "Air", new Nation("Air") },
            { "Water", new Nation("Water") },
            { "Fire", new Nation("Fire") },
            { "Earth", new Nation("Earth") }
        };
    }

    public void AssignBender(List<string> benderArgs)
    {
        string type = benderArgs[0];
        string name = benderArgs[1];
        int power = int.Parse(benderArgs[2]);
        double specialPower = double.Parse(benderArgs[3]);

        Bender bender = BenderFactory.CreateBender(type, name, power, specialPower);
        this.nations[type].AddBender(bender);
    }

    public void AssignMonument(List<string> monumentArgs)
    {
        string type = monumentArgs[0];
        string name = monumentArgs[1];
        int affinity = int.Parse(monumentArgs[2]);

        Monument monument = MonumentFactory.CreateMonument(type, name, affinity);
        this.nations[type].AddMonument(monument);
    }

    public string GetStatus(string nationsType)
    {
        return this.nations[nationsType].ToString();
    }

    public void IssueWar(string nationsType)
    {
        //double winnerNationPower = this.nations.Max(nation => nation.Value.GetNationTotalPower());
        //
        //foreach (Nation nation in this.nations.Values)
        //{
        //    if (nation.GetNationTotalPower() != winnerNationPower)
        //    {
        //        nation.DeleteAllBendersAndMonuments();
        //    }
        //}

        double airTotalPower = this.nations["Air"].GetNationTotalPower();
        double waterTotalPower = this.nations["Water"].GetNationTotalPower();
        double fireTotalPower = this.nations["Fire"].GetNationTotalPower();
        double earthTotalPower = this.nations["Earth"].GetNationTotalPower();

        double winnerNationPower = Math.Max(airTotalPower, Math.Max(waterTotalPower, Math.Max(fireTotalPower, earthTotalPower)));

        if (airTotalPower == winnerNationPower)
        {
            this.nations["Water"].DeleteAllBendersAndMonuments();
            this.nations["Fire"].DeleteAllBendersAndMonuments();
            this.nations["Earth"].DeleteAllBendersAndMonuments();
        }
        else if (waterTotalPower == winnerNationPower)
        {
            this.nations["Air"].DeleteAllBendersAndMonuments();
            this.nations["Fire"].DeleteAllBendersAndMonuments();
            this.nations["Earth"].DeleteAllBendersAndMonuments();
        }
        else if (fireTotalPower == winnerNationPower)
        {
            this.nations["Air"].DeleteAllBendersAndMonuments();
            this.nations["Water"].DeleteAllBendersAndMonuments();
            this.nations["Earth"].DeleteAllBendersAndMonuments();
        }
        else if (earthTotalPower == winnerNationPower)
        {
            this.nations["Air"].DeleteAllBendersAndMonuments();
            this.nations["Water"].DeleteAllBendersAndMonuments();
            this.nations["Fire"].DeleteAllBendersAndMonuments();
        }

        this.issuedWarsCount++;
        this.issuedWars.AppendLine($"War {issuedWarsCount} issued by {nationsType}");
    }

    public string GetWarsRecord()
    {
        return this.issuedWars.ToString().Trim();
    }
}