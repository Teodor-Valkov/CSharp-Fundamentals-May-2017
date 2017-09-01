namespace _01.RecyclingStation.Strategies
{
    using _01.RecyclingStation.WasteDisposal.Interfaces;

    public class BurnableGarbageDisposalStrategy : GarbageDisposalStrategy
    {
        public override double CalculateCapitalBalance(IWaste garbage)
        {
            return 0;
        }

        public override double CalculateEnergyBalance(IWaste garbage)
        {
            double energyProduced = garbage.CalculateWasteTotalVolume();
            double energyUsed = garbage.CalculateWasteTotalVolume() * 0.2;

            return energyProduced - energyUsed;
        }
    }
}