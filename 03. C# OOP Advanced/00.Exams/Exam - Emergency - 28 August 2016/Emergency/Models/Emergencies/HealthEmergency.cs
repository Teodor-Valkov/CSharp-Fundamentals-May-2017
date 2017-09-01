namespace _01.Emergency.Models.Emergencies
{
    using _01.Emergency.Contracts;
    using _01.Emergency.Enums;

    public class HealthEmergency : Emergency
    {
        private int countCasualties;

        public HealthEmergency(string description, EmergencyLevel emergencyLevel, IRegistrationTime registrationTime, int countCasualties)
            : base(description, emergencyLevel, registrationTime)
        {
            this.countCasualties = countCasualties;
        }

        public override int GetResultAfterProcessing()
        {
            return this.countCasualties;
        }
    }
}