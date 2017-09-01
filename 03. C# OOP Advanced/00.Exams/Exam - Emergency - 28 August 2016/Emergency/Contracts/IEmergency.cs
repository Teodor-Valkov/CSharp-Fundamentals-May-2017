namespace _01.Emergency.Contracts
{
    using _01.Emergency.Enums;

    public interface IEmergency
    {
        string Description { get; }

        EmergencyLevel EmergencyLevel { get; }

        IRegistrationTime RegistrationTime { get; }

        int GetResultAfterProcessing();
    }
}