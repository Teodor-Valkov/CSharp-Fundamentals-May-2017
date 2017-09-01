namespace _01.Emergency.Models.Emergencies
{
    using _01.Emergency.Contracts;
    using _01.Emergency.Enums;

    public abstract class Emergency : IEmergency
    {
        private string description;
        private EmergencyLevel emergencyLevel;
        private IRegistrationTime registrationTime;

        protected Emergency(string description, EmergencyLevel emergencyLevel, IRegistrationTime registrationTime)
        {
            this.Description = description;
            this.EmergencyLevel = emergencyLevel;
            this.RegistrationTime = registrationTime;
        }

        public string Description
        {
            get { return this.description; }
            private set { this.description = value; }
        }

        public EmergencyLevel EmergencyLevel
        {
            get { return this.emergencyLevel; }
            private set { this.emergencyLevel = value; }
        }

        public IRegistrationTime RegistrationTime
        {
            get { return this.registrationTime; }
            private set { this.registrationTime = value; }
        }

        public abstract int GetResultAfterProcessing();
    }
}