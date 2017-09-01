namespace _01.RecyclingStation.WasteDisposal.Interfaces
{
    public interface IGarbageProcessor
    {
        IStrategyHolder StrategyHolder { get; }

        IProcessingData ProcessWaste(IWaste garbage);
    }
}