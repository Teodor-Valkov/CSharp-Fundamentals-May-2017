public class PressureProvider : Provider
{
    public PressureProvider(string id, double energyOutput)
        : base(id, energyOutput)
    {
        this.ModifyStats();
    }

    private void ModifyStats()
    {
        base.EnergyOutput += base.EnergyOutput * 0.5;
    }
}