using _01.RecyclingStation.Attributes;
using _01.RecyclingStation.Strategies;

namespace _01.RecyclingStation.Models.Garbages
{
    [RecyclableStrategy(typeof(RecyclableGarbageDisposalStrategy))]
    public class RecyclableGarbage : Garbage
    {
        public RecyclableGarbage(string name, double volumePerKg, double weight)
            : base(name, volumePerKg, weight)
        {
        }
    }
}