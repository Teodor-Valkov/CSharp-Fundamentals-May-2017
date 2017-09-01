namespace Emergency.Models.Emergencies
{
    using Contracts.Utils;
    using Enums;

    public class HealthEmergency : BaseEmergency
    {
        public HealthEmergency(string description, EmergencyLevel emergencyLevel, IRegistrationTime registrationTime, int casualties)
            : base(description, emergencyLevel, registrationTime)
        {
            this.Casualties = casualties;
        }

        public int Casualties { get; }

        public override int GetProcessResult()
        {
            return this.Casualties;
        }
    }
}