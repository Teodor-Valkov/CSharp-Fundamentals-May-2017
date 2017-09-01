namespace _01.SystemSplit.Models.Hardwares
{
    using Utilities;

    public class HeavyHardware : Hardware
    {
        public HeavyHardware(string name, string type, int maximumCapacity, int maximumMemory)
            : base(name, type, maximumCapacity, maximumMemory)
        {
            this.ModifyStats();
        }

        private void ModifyStats()
        {
            base.MaximumCapacity *= Constants.HeavyHardwareIncreaseCapacityModifier;
            base.MaximumMemory -= (base.MaximumMemory * Constants.HeavyHardwareDecreaseMemoryPercentage) / Constants.MaximumPercentage;
        }
    }
}