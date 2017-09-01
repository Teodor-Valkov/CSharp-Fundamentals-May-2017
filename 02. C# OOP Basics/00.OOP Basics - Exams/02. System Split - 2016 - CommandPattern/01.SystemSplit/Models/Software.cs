public abstract class Software : Component
{
    private string hardwareName;
    private int capacityConsumption;
    private int memoryConsumption;

    protected Software(string type, string hardware, string name, int capacityConsumption, int memoryConsumption)
        : base(type, name)
    {
        this.hardwareName = hardware;
        this.CapacityConsumption = capacityConsumption;
        this.MemoryConsumption = memoryConsumption;
    }

    public virtual int CapacityConsumption
    {
        get
        {
            return this.capacityConsumption;
        }
        protected set
        {
            this.capacityConsumption = value;
        }
    }

    public virtual int MemoryConsumption
    {
        get
        {
            return this.memoryConsumption;
        }
        protected set
        {
            this.memoryConsumption = value;
        }
    }

    public override string ToString()
    {
        return this.Name;
    }
}