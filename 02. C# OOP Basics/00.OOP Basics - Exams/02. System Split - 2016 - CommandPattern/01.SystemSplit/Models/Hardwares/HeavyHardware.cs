public class HeavyHardware : Hardware
{
    private const string Type = "Heavy";
    private const int IncreasedMaxCapacityMultiplier = 2;
    private const int MaxMemoryDivisor = 4;

    public HeavyHardware(string name, int maxCapacity, int maxMemory)
        : base(Type, name, maxCapacity, maxMemory)
    {
    }

    public override int MaxCapacity
    {
        protected set
        {
            base.MaxCapacity = value * IncreasedMaxCapacityMultiplier;
        }
    }

    public override int MaxMemory
    {
        protected set
        {
            base.MaxMemory = value - value / MaxMemoryDivisor;
        }
    }
}