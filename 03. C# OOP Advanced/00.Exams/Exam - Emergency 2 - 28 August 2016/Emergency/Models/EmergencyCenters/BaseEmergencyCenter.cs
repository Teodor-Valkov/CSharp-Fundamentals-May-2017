namespace Emergency.Models.EmergencyCenters
{
    using Contracts.Models.Emergencies;
    using Contracts.Models.EmergencyCenters;

    public abstract class BaseEmergencyCenter : IEmergencyCenter
    {
        private int processedEmergencies;

        protected BaseEmergencyCenter(string name, int amountOfMaximumEmergencies)
        {
            this.Name = name;
            this.AmountOfMaximumEmergencies = amountOfMaximumEmergencies;
            this.processedEmergencies = 0;
        }

        public string Name { get; }

        public int AmountOfMaximumEmergencies { get; }

        public bool IsForRetirement()
        {
            return this.processedEmergencies >= this.AmountOfMaximumEmergencies;
        }

        public int ProcessEmergency(IEmergency emergency)
        {
            this.processedEmergencies++;
            return emergency.GetProcessResult();
        }

        public override string ToString()
        {
            return $"Registered {{0}} Service Emergency Center - {this.Name}.";
        }
    }
}