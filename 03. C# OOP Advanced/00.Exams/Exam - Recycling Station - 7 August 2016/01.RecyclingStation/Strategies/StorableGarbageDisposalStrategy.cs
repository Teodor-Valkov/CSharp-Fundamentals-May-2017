namespace _01.RecyclingStation.Strategies
{
    using _01.RecyclingStation.WasteDisposal.Interfaces;

    public class StorableGarbageDisposalStrategy : GarbageDisposalStrategy
    {
        public override double CalculateCapitalBalance(IWaste garbage)
        {
            double capitalEarned = 0;
            double capitalUsed = garbage.CalculateWasteTotalVolume() * 0.65;

            return capitalEarned - capitalUsed;
        }

        public override double CalculateEnergyBalance(IWaste garbage)
        {
            double energyProduced = 0;
            double energyUsed = garbage.CalculateWasteTotalVolume() * 0.13;

            return energyProduced - energyUsed;
        }
    }
}