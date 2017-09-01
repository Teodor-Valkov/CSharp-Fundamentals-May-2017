public class HammerHarvester : Harvester
{
    public HammerHarvester(string id, double oreOutput, double energyRequirement)
        : base(id, oreOutput, energyRequirement)
    {
        this.ModifyStats();
    }

    private void ModifyStats()
    {
        base.OreOutput += base.OreOutput * 2;
        base.EnergyRequirement += base.EnergyRequirement;
    }
}