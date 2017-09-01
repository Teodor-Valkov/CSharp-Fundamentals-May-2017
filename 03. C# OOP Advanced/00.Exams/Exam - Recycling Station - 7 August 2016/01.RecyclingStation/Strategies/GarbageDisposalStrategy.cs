namespace _01.RecyclingStation.Strategies
{
    using _01.RecyclingStation.Data;
    using _01.RecyclingStation.WasteDisposal.Interfaces;

    public abstract class GarbageDisposalStrategy : IGarbageDisposalStrategy
    {
        public IProcessingData ProcessGarbage(IWaste garbage)
        {
            double energyBalance = this.CalculateEnergyBalance(garbage);
            double capitalBalance = this.CalculateCapitalBalance(garbage);

            return new ProcessingData(energyBalance, capitalBalance);
        }

        public abstract double CalculateEnergyBalance(IWaste garbage);

        public abstract double CalculateCapitalBalance(IWaste garbage);
    }
}