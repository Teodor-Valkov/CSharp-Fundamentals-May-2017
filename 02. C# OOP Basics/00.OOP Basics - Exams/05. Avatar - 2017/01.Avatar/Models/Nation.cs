using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Nation
{
    private string type;
    private List<Bender> benders;
    private List<Monument> monuments;

    public Nation(string type)
    {
        this.type = type;
        this.benders = new List<Bender>();
        this.monuments = new List<Monument>();
    }

    public void AddBender(Bender bender)
    {
        this.benders.Add(bender);
    }

    public void AddMonument(Monument monument)
    {
        this.monuments.Add(monument);
    }

    private double GetBendersTotalPower()
    {
        return this.benders.Sum(bender => bender.GetBenderPower());
    }

    private int GetMonumentsTotalPower()
    {
        return this.monuments.Sum(monument => monument.GetMonumentPower());
    }

    public double GetNationTotalPower()
    {
        double monumentsIncreasePercentage = (this.GetBendersTotalPower() / 100) * this.GetMonumentsTotalPower();

        return this.GetBendersTotalPower() + monumentsIncreasePercentage;
    }

    public void DeleteAllBendersAndMonuments()
    {
        this.benders.Clear();
        this.monuments.Clear();
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.type} Nation");

        //sb.AppendLine(this.benders.Count == 0
        //    ? "Benders: None"
        //    : string.Join(Environment.NewLine, this.benders.Select(bender => $"###{bender}")));

        if (this.benders.Count == 0)
        {
            sb.AppendLine("Benders: None");
        }
        else
        {
            sb.AppendLine("Benders:");
            foreach (Bender bender in this.benders)
            {
                sb.AppendLine($"###{bender}");
            }
        }

        //sb.AppendLine(this.monuments.Count == 0
        //    ? "Monuments: None"
        //    : string.Join(Environment.NewLine, this.monuments.Select(monument => $"###{monument}")));

        if (this.monuments.Count == 0)
        {
            sb.AppendLine("Monuments: None");
        }
        else
        {
            sb.AppendLine("Monuments:");
            foreach (Monument monument in this.monuments)
            {
                sb.AppendLine($"###{monument}");
            }
        }

        return sb.ToString().Trim();
    }
}