namespace RecyclingStation.Models.Strategies
{
    using Data;
    using WasteDisposal.Interfaces;

    public class StorableGarbageStrategy : GarbageDisposalStrategy
    {
        public override IProcessingData ProcessGarbage(IWaste garbage)
        {
            double capitalBalance = 0;
            double energyBalance = 0;

            energyBalance -= garbage.GetTotalGarbageVolume() * 0.13;
            capitalBalance -= garbage.GetTotalGarbageVolume() * 0.65;

            return new GarbageProcessingData(capitalBalance, energyBalance);
        }
    }
}