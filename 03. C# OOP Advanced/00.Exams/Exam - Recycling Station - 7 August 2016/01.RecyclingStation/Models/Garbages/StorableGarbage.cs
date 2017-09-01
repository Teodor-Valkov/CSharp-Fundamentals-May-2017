using _01.RecyclingStation.Attributes;
using _01.RecyclingStation.Strategies;

namespace _01.RecyclingStation.Models.Garbages
{
    [StorableStrategy(typeof(StorableGarbageDisposalStrategy))]
    public class StorableGarbage : Garbage
    {
        public StorableGarbage(string name, double volumePerKg, double weight)
            : base(name, volumePerKg, weight)
        {
        }
    }
}