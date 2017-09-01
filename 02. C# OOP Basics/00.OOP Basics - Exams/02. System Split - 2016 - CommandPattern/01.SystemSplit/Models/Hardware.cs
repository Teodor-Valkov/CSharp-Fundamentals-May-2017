using System.Collections.Generic;
using System.Linq;

public abstract class Hardware : Component
{
    private int maxCapacity;
    private int maxMemory;
    private int capacityInUse;
    private int memoryInUse;
    private List<Software> software;

    protected Hardware(string type, string name, int maxCapacity, int maxMemory)
        : base(type, name)
    {
        this.MaxCapacity = maxCapacity;
        this.MaxMemory = maxMemory;
        this.software = new List<Software>();
    }

    public virtual int MaxCapacity
    {
        get
        {
            return this.maxCapacity;
        }
        protected set
        {
            this.maxCapacity = value;
        }
    }

    public virtual int MaxMemory
    {
        get
        {
            return this.maxMemory;
        }
        protected set
        {
            this.maxMemory = value;
        }
    }

    public int CapacityInUse
    {
        get
        {
            return this.capacityInUse;
        }
    }

    public int MemoryInUse
    {
        get
        {
            return this.memoryInUse;
        }
    }

    public IReadOnlyList<Software> Softwares
    {
        get
        {
            return this.software;
        }
    }

    public bool CanRegisterSoftware(Software software)
    {
        if (software.CapacityConsumption + this.capacityInUse <= this.maxCapacity && software.MemoryConsumption + this.memoryInUse <= this.maxMemory)
        {
            return true;
        }

        return false;
    }

    public void RegisterSoftware(Software software)
    {
        this.capacityInUse += software.CapacityConsumption;
        this.memoryInUse += software.MemoryConsumption;

        this.software.Add(software);
    }

    public void ReleaseSoftware(string softwareName)
    {
        Software software = this.software.First(s => s.Name == softwareName);

        this.capacityInUse -= software.CapacityConsumption;
        this.memoryInUse -= software.MemoryConsumption;
        this.software.Remove(software);
    }

    public void RemoveSoftware(string softwareName)
    {
        this.software.RemoveAll(software => software.Name == softwareName);
    }
}