namespace _01.RecyclingStation.WasteDisposal.Interfaces
{
    public interface IWaste
    {
        string Name { get; }

        double VolumePerKg { get; }

        double Weight { get; }
    }
}