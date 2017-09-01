namespace RecyclingStation.Models.Data
{
    using WasteDisposal.Interfaces;

    public abstract class ProcessingData : IProcessingData
    {
        private double capitalBalance;
        private double energyBalance;

        protected ProcessingData(double capitalBalance, double energyBalance)
        {
            this.EnergyBalance = energyBalance;
            this.CapitalBalance = capitalBalance;
        }

        public double CapitalBalance
        {
            get
            {
                return this.capitalBalance;
            }
            private set
            {
                this.capitalBalance = value;
            }
        }

        public double EnergyBalance
        {
            get
            {
                return this.energyBalance;
            }
            private set
            {
                this.energyBalance = value;
            }
        }
    }
}