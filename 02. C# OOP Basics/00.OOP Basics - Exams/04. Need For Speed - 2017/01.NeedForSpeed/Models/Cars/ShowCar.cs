using System.Text;

public class ShowCar : Car
{
    private int stars;

    public ShowCar(string brand, string model, int yearOfProduction, int horsePower, int acceleration, int suspension, int durability)
        : base(brand, model, yearOfProduction, horsePower, acceleration, suspension, durability)
    {
    }

    public override void TuneCar(int tuneIndex, string tuneAddOn)
    {
        base.TuneCar(tuneIndex, tuneAddOn);
        this.stars += tuneIndex;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder(base.ToString());

        sb.Append($"{this.stars} *");

        return sb.ToString();
    }
}