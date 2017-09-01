using System.Collections.Generic;
using System.Text;

public class PerformanceCar : Car
{
    private List<string> addOns;

    public PerformanceCar(string brand, string model, int yearOfProduction, int horsePower, int acceleration, int suspension, int durability)
        : base(brand, model, yearOfProduction, horsePower, acceleration, suspension, durability)
    {
        //this.ModifyStats();
        this.addOns = new List<string>();
    }

    //private void ModifyStats()
    //{
    //    base.Horsepower += base.Horsepower * Constants.HorsepowerPercentageModifier / Constants.MaximumPercentage;
    //    base.Suspension -= base.Suspension * Constants.SuspensionPercentageModifier / Constants.MaximumPercentage;
    //}

    public override int Horsepower
    {
        get
        {
            return base.Horsepower;
        }
        protected set
        {
            base.Horsepower = value + value * Constants.HorsepowerPercentageModifier / Constants.MaximumPercentage;
        }
    }

    public override int Suspension
    {
        get
        {
            return base.Suspension;
        }
        protected set
        {
            base.Suspension = value - value * Constants.SuspensionPercentageModifier / Constants.MaximumPercentage;
        }
    }

    public override void TuneCar(int tuneIndex, string tuneAddOn)
    {
        base.TuneCar(tuneIndex, tuneAddOn);
        this.addOns.Add(tuneAddOn);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder(base.ToString());

        sb.Append(this.addOns.Count == 0
            ? "Add-ons: None"
            : $"Add-ons: {string.Join(", ", this.addOns)}");

        return sb.ToString();
    }
}