public class NightVision : Ammunition
{
    public const double WeightConst = 0.8;

    public NightVision(string name)
        : base(name)
    {
        this.Weight = WeightConst;
        this.WearLevel = this.Weight * 100;
    }
}