public class MachineGun : Ammunition
{
    public const double WeightConst = 10.6;

    public MachineGun(string name)
        : base(name)
    {
        this.Weight = WeightConst;
        this.WearLevel = this.Weight * 100;
    }
}