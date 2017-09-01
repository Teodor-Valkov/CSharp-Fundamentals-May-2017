namespace _01.RecyclingStation.Contracts.Core
{
    public interface IRecyclingStationManager
    {
        string ProcessGarbage(string name, double weight, double volumePerKg, string type);

        string Status();

        string ChangeManagementRequirement(double minimumEnergyBalance, double minimumCapitalBalance, string typeOfGarbage);
    }
}