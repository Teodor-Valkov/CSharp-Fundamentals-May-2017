namespace _01.SystemSplit.Models.Hardwares
{
    using Utilities;

    public class PowerHardware : Hardware
    {
        public PowerHardware(string name, string type, int maximumCapacity, int maximumMemory)
            : base(name, type, maximumCapacity, maximumMemory)
        {
            this.ModifyStats();
        }

        private void ModifyStats()
        {
            base.MaximumCapacity -= (base.MaximumCapacity * Constants.PowerHardwareDecreaseCapacityPercentage) / Constants.MaximumPercentage;
            base.MaximumMemory += (base.MaximumMemory * Constants.PowerHardwareIncreaseMememoryPercentage) / Constants.MaximumPercentage;
        }
    }
}