namespace Emergency.Contracts.Models.EmergencyCenters
{
    using Emergencies;

    public interface IEmergencyCenter
    {
        string Name { get; }

        int AmountOfMaximumEmergencies { get; }

        int ProcessEmergency(IEmergency emergency);

        bool IsForRetirement();
    }
}