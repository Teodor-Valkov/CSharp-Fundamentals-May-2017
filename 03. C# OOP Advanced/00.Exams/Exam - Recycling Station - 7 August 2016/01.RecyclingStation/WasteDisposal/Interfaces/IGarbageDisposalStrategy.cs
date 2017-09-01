namespace _01.RecyclingStation.WasteDisposal.Interfaces
{
    public interface IGarbageDisposalStrategy
    {
        IProcessingData ProcessGarbage(IWaste garbage);
    }
}