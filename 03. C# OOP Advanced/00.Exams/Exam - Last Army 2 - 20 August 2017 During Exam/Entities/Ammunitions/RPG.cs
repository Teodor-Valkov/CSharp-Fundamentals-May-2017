public class RPG : Ammunition
{
    public const double WeightConst = 17.1;

    public RPG(string name)
        : base(name)
    {
        this.Weight = WeightConst;
        this.WearLevel = this.Weight * 100;
    }
}