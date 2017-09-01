namespace RecyclingStation.Models.Strategies
{
    using Data;
    using WasteDisposal.Interfaces;

    public class RecyclableGarbageStrategy : GarbageDisposalStrategy
    {
        public override IProcessingData ProcessGarbage(IWaste garbage)
        {
            double energyBalance = 0;
            double capitalBalance = 0;

            energyBalance -= (garbage.GetTotalGarbageVolume() * 0.5);
            capitalBalance += (400.00 * garbage.Weight);

            return new GarbageProcessingData(capitalBalance, energyBalance);
        }
    }
}