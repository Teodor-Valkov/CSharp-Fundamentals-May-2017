using System;
using System.Text;

public abstract class Harvester : Villager
{
    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement)
        : base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public double OreOutput
    {
        get
        {
            return this.oreOutput;
        }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException(nameof(this.OreOutput));
            }

            this.oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get
        {
            return this.energyRequirement;
        }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException(nameof(this.EnergyRequirement));
            }

            if (value > 20000)
            {
                throw new ArgumentException(nameof(this.EnergyRequirement));
            }

            this.energyRequirement = value;
        }
    }

    public double GetRequiredEnergyPerHarvester(string mode)
    {
        switch (mode)
        {
            case "Full":
                return this.EnergyRequirement;

            case "Half":
                return this.EnergyRequirement * 0.6;
        }

        return 0;
    }

    public double GetOreOutputPerHarvester(string mode)
    {
        switch (mode)
        {
            case "Full":
                return this.OreOutput;

            case "Half":
                return this.OreOutput * 0.5;
        }

        return 0;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        int typeIndexEnd = this.GetType().Name.IndexOf("Harvester");
        string type = this.GetType().Name.Remove(typeIndexEnd);

        sb.AppendLine($"{type} Harvester - {this.GetId()}");
        sb.AppendLine($"Ore Output: {this.oreOutput}");
        sb.AppendLine($"Energy Requirement: {this.energyRequirement}");

        return sb.ToString().Trim();
    }
}