namespace RecyclingStation.WasteDisposal.Interfaces
{
    public interface IStation
    {
        string ProcessGarbage(string[] input);

        string Status();
    }
}