namespace _01.RecyclingStation.Data
{
    using _01.RecyclingStation.WasteDisposal.Interfaces;

    public class ProcessingData : IProcessingData
    {
        public ProcessingData(double energyBalance, double capitalBalance)
        {
            this.EnergyBalance = energyBalance;
            this.CapitalBalance = capitalBalance;
        }

        public double EnergyBalance { get; private set; }

        public double CapitalBalance { get; private set; }
    }
}