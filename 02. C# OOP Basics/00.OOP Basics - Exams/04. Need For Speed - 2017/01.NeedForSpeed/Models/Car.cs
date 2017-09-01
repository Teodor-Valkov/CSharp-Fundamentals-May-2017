using System.Text;

public abstract class Car
{
    private string brand;
    private string model;
    private int yearOfProduction;
    private int horsepower;
    private int acceleration;
    private int suspension;
    private int durability;

    protected Car(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        this.brand = brand;
        this.model = model;
        this.yearOfProduction = yearOfProduction;
        this.Horsepower = horsepower;
        this.acceleration = acceleration;
        this.Suspension = suspension;
        this.durability = durability;
    }

    public string Brand
    {
        get
        {
            return this.brand;
        }
    }

    public string Model
    {
        get
        {
            return this.model;
        }
    }

    public int YearOfProduction
    {
        get
        {
            return this.yearOfProduction;
        }
    }

    public int Acceleration
    {
        get
        {
            return this.acceleration;
        }
    }

    public int Durability
    {
        get
        {
            return this.durability;
        }
        protected set
        {
            this.durability = value;
        }
    }

    public virtual int Horsepower
    {
        get
        {
            return this.horsepower;
        }
        protected set
        {
            this.horsepower = value;
        }
    }

    public virtual int Suspension
    {
        get
        {
            return this.suspension;
        }
        protected set
        {
            this.suspension = value;
        }
    }

    public int GetEnginePerformance()
    {
        return this.Horsepower / this.Acceleration;
    }

    public int GetSuspensionPerformance()
    {
        return this.Suspension + this.Durability;
    }

    public int GetOverallPerformance()
    {
        return this.GetEnginePerformance() + this.GetSuspensionPerformance();
    }

    public void DecreaseDurabilityPerLap(int lap)
    {
        this.Durability = this.Durability - lap;
    }

    public virtual void TuneCar(int tuneIndex, string tuneAddOn)
    {
        this.horsepower += tuneIndex;
        this.suspension += tuneIndex / Constants.TuningSuspensionModifier;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"{this.brand} {this.model} {this.yearOfProduction}");
        sb.AppendLine($"{this.horsepower} HP, 100 m/h in {this.acceleration} s");
        sb.AppendLine($"{this.Suspension} Suspension force, {this.durability} Durability");

        return sb.ToString();
    }
}