namespace _01.SystemSplit.Models.Softwares
{
    using Utilities;

    public class ExpressSoftware : Software
    {
        public ExpressSoftware(string name, string type, int capacityConsumption, int memoryConsumption)
            : base(name, type, capacityConsumption, memoryConsumption)
        {
            this.ModifyStats();
        }

        private void ModifyStats()
        {
            base.MemoryConsumption *= Constants.ExpressSoftwareIncreaseMemoryModifier;
        }
    }
}