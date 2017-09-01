namespace _01.RecyclingStation.Contracts.Factories
{
    using _01.RecyclingStation.WasteDisposal.Interfaces;

    public interface IWasteFactory
    {
        IWaste CreateGarbage(string name, double weight, double volumePerKg, string type);
    }
}