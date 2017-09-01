namespace _01.RecyclingStation.Strategies
{
    using _01.RecyclingStation.WasteDisposal.Interfaces;

    public class RecyclableGarbageDisposalStrategy : GarbageDisposalStrategy
    {
        public override double CalculateCapitalBalance(IWaste garbage)
        {
            double capitalEarned = garbage.Weight * 400;
            double capitalUsed = 0;

            return capitalEarned - capitalUsed;
        }

        public override double CalculateEnergyBalance(IWaste garbage)
        {
            double energyProduced = 0;
            double energyUsed = garbage.CalculateWasteTotalVolume() * 0.5;

            return energyProduced - energyUsed;
        }
    }
}