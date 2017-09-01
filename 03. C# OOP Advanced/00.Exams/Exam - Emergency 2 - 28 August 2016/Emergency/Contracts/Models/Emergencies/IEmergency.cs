namespace Emergency.Contracts.Models.Emergencies
{
    using Enums;
    using Utils;

    public interface IEmergency
    {
        string Description { get; }

        EmergencyLevel Level { get; }

        IRegistrationTime Time { get; }

        int GetProcessResult();
    }
}