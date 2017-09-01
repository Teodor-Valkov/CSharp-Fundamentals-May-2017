namespace _01.Emergency.Models.Centers
{
    using _01.Emergency.Contracts;

    public abstract class EmergencyCenter : IEmergencyCenter
    {
        private string name;
        private int processedEmergencies;
        private int amountOfMaximumEmergencies;

        protected EmergencyCenter(string name, int amountOfMaximumEmergencies)
        {
            this.Name = name;
            this.AmountOfMaximumEmergencies = amountOfMaximumEmergencies;
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public int ProcessedEmergencies
        {
            get { return this.processedEmergencies; }
            private set { this.processedEmergencies = value; }
        }

        public int AmountOfMaximumEmergencies
        {
            get { return this.amountOfMaximumEmergencies; }
            private set { this.amountOfMaximumEmergencies = value; }
        }

        public void ProcessEmergency()
        {
            this.ProcessedEmergencies++;
        }

        public bool IsForRetirement()
        {
            return this.ProcessedEmergencies >= this.AmountOfMaximumEmergencies;
        }
    }
}