namespace _01.Emergency.Models.Emergencies
{
    using _01.Emergency.Contracts;
    using _01.Emergency.Enums;

    public class PropertyEmergency : Emergency
    {
        private int damage;

        public PropertyEmergency(string description, EmergencyLevel emergencyLevel, IRegistrationTime registrationTime, int damage)
            : base(description, emergencyLevel, registrationTime)
        {
            this.damage = damage;
        }

        public override int GetResultAfterProcessing()
        {
            return this.damage;
        }
    }
}