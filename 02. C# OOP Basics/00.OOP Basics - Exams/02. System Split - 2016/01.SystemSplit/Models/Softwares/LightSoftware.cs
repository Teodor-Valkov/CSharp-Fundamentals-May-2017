namespace _01.SystemSplit.Models.Softwares
{
    using Utilities;

    public class LightSoftware : Software
    {
        public LightSoftware(string name, string type, int capacityConsumption, int memoryConsumption) :
            base(name, type, capacityConsumption, memoryConsumption)
        {
            this.ModifyStats();
        }

        private void ModifyStats()
        {
            base.CapacityConsumption += (base.CapacityConsumption * Constants.LightSoftwareIncreaseCapacityPercentage) / Constants.MaximumPercentage;
            base.MemoryConsumption -= (base.MemoryConsumption * Constants.LightSoftwareDecreaseMemoryPercentage) / Constants.MaximumPercentage;
        }
    }
}