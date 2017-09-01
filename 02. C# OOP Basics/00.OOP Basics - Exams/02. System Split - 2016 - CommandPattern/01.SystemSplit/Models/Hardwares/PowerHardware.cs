public class PowerHardware : Hardware
{
    private const string Type = "Power";
    private const int MaxCapacityDivisor = 4;
    private const int MaxMemoryMultiplier = 3;
    private const int MaxMemoryDivisor = 4;

    public PowerHardware(string name, int maxCapacity, int maxMemory)
        : base(Type, name, maxCapacity, maxMemory)
    {
    }

    public override int MaxCapacity
    {
        protected set
        {
            base.MaxCapacity = value / MaxCapacityDivisor;
        }
    }

    public override int MaxMemory
    {
        protected set
        {
            base.MaxMemory = value + value / MaxMemoryDivisor * MaxMemoryMultiplier;
        }
    }
}