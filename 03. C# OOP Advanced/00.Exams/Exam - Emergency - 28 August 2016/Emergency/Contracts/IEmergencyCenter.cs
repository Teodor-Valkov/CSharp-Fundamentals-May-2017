namespace _01.Emergency.Contracts
{
    public interface IEmergencyCenter
    {
        string Name { get; }

        int AmountOfMaximumEmergencies { get; }

        int ProcessedEmergencies { get; }

        void ProcessEmergency();

        bool IsForRetirement();
    }
}