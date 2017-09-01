namespace RecyclingStation.Models.Strategies
{
    using Data;
    using WasteDisposal.Interfaces;

    public class BurnableGarbageStrategy : GarbageDisposalStrategy
    {
        public override IProcessingData ProcessGarbage(IWaste garbage)
        {
            double capitalBalance = 0;
            double energyBalance = 0;

            energyBalance += garbage.GetTotalGarbageVolume() - garbage.GetTotalGarbageVolume() * 0.2;

            return new GarbageProcessingData(capitalBalance, energyBalance);
        }
    }
}