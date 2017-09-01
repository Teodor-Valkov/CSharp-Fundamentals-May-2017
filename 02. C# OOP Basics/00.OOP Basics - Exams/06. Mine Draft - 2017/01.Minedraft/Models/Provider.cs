using System;
using System.Text;

public abstract class Provider : Villager
{
    private double energyOutput;

    protected Provider(string id, double energyOutput)
        : base(id)
    {
        this.EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get
        {
            return this.energyOutput;
        }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException(nameof(this.EnergyOutput));
            }

            if (value > 10000)
            {
                throw new ArgumentException(nameof(this.EnergyOutput));
            }

            this.energyOutput = value;
        }
    }

    public double GetProvidedEnergyPerProvider()
    {
        return this.EnergyOutput;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        int typeIndexEnd = this.GetType().Name.IndexOf("Provider");
        string type = this.GetType().Name.Remove(typeIndexEnd);

        sb.AppendLine($"{type} Provider - {this.GetId()}");
        sb.AppendLine($"Energy Output: {this.energyOutput}");

        return sb.ToString().Trim();
    }
}