namespace RecyclingStation.Models.Strategies
{
    using WasteDisposal.Interfaces;

    public abstract class GarbageDisposalStrategy : IGarbageDisposalStrategy
    {
        public abstract IProcessingData ProcessGarbage(IWaste garbage);
    }
}