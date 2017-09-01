namespace Emergency.Models.Emergencies
{
    using Contracts.Models.Emergencies;
    using Contracts.Utils;
    using Enums;

    public abstract class BaseEmergency : IEmergency
    {
        private string description;
        private EmergencyLevel emergencyLevel;
        private IRegistrationTime registrationTime;

        protected BaseEmergency(string description, EmergencyLevel emergencyLevel, IRegistrationTime registrationTime)
        {
            this.Description = description;
            this.Level = emergencyLevel;
            this.Time = registrationTime;
        }

        public string Description
        {
            get { return this.description; }
            private set { this.description = value; }
        }

        public EmergencyLevel Level
        {
            get { return this.emergencyLevel; }
            private set { this.emergencyLevel = value; }
        }

        public IRegistrationTime Time
        {
            get { return this.registrationTime; }
            private set { this.registrationTime = value; }
        }

        public abstract int GetProcessResult();

        public override string ToString()
        {
            return $"Registered Public {{0}} Emergency of level {this.Level.ToString()} at {this.Time}.";
        }
    }
}