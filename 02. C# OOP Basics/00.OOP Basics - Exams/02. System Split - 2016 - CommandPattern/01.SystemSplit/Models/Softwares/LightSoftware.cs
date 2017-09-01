public class LightSoftware : Software
{
    private const string Type = "Light Software";
    private const int CapacityConsumptionMultiplier = 2;
    private const int MemoryConsumptionDivisor = 2;

    public LightSoftware(string hardware, string name, int capacityConsumption, int memoryConsumption)
        : base(Type, hardware, name, capacityConsumption, memoryConsumption)
    {
    }

    public override int CapacityConsumption
    {
        protected set
        {
            base.CapacityConsumption = value + value / CapacityConsumptionMultiplier;
        }
    }

    public override int MemoryConsumption
    {
        protected set
        {
            base.MemoryConsumption = value - value / MemoryConsumptionDivisor;
        }
    }
}