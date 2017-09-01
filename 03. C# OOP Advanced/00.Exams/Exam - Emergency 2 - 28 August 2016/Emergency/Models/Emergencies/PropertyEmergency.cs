namespace Emergency.Models.Emergencies
{
    using Contracts.Utils;
    using Enums;

    public class PropertyEmergency : BaseEmergency
    {
        public PropertyEmergency(string description, EmergencyLevel emergencyLevel, IRegistrationTime registrationTime, int damage)
            : base(description, emergencyLevel, registrationTime)
        {
            this.Damage = damage;
        }

        public int Damage { get; }

        public override int GetProcessResult()
        {
            return this.Damage;
        }
    }
}