using _01.RecyclingStation.Attributes;
using _01.RecyclingStation.Strategies;

namespace _01.RecyclingStation.Models.Garbages
{
    [BurnableStrategy(typeof(BurnableGarbageDisposalStrategy))]
    public class BurnableGarbage : Garbage
    {
        public BurnableGarbage(string name, double volumePerKg, double weight)
            : base(name, volumePerKg, weight)
        {
        }
    }
}