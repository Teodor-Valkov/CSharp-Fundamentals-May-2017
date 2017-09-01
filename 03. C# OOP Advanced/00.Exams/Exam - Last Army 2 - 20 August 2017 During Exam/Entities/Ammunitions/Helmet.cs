public class Helmet : Ammunition
{
    public const double WeightConst = 2.3;

    public Helmet(string name)
        : base(name)
    {
        this.Weight = WeightConst;
        this.WearLevel = this.Weight * 100;
    }
}