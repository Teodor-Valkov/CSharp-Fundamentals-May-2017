using RecyclingStation.WasteDisposal.Attributes;

namespace RecyclingStation.Models.Waste
{
    [RecyclableGarbageStrategy]
    public class RecyclableGarbage : Waste
    {
        public RecyclableGarbage(string name, double volumePerKg, double weight)
            : base(name, volumePerKg, weight)
        {
        }
    }
}