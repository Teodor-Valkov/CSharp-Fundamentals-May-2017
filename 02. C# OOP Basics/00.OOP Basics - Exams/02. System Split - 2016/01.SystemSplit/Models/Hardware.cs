namespace _01.SystemSplit.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Hardware : Component
    {
        private int maximumCapacity;
        private int maximumMemory;
        private int capacityInUse;
        private int memoryInUse;
        private List<Software> softwares;

        protected Hardware(string name, string type, int maximumCapacity, int maximumMemory)
            : base(name, type)
        {
            this.maximumCapacity = maximumCapacity;
            this.maximumMemory = maximumMemory;
            this.softwares = new List<Software>();
        }

        public int MaximumCapacity
        {
            get
            {
                return this.maximumCapacity;
            }
            protected set
            {
                this.maximumCapacity = value;
            }
        }

        public int MaximumMemory
        {
            get
            {
                return this.maximumMemory;
            }
            protected set
            {
                this.maximumMemory = value;
            }
        }

        public int CapacityInUse
        {
            get
            {
                return this.capacityInUse;
            }
            private set
            {
                this.capacityInUse = value;
            }
        }

        public int MemoryInUse
        {
            get
            {
                return this.memoryInUse;
            }
            private set
            {
                this.memoryInUse = value;
            }
        }

        public bool CanSoftwareBeAdded(Software software)
        {
            if (this.CapacityInUse + software.CapacityConsumption <= this.maximumCapacity && this.MemoryInUse + software.MemoryConsumption <= this.MaximumMemory)
            {
                return true;
            }

            return false;
        }

        public void AddSoftware(Software software)
        {
            this.CapacityInUse += software.CapacityConsumption;
            this.MemoryInUse += software.MemoryConsumption;

            this.softwares.Add(software);
        }

        public bool IsSoftwareExisting(string softwareName)
        {
            return this.softwares.Any(software => software.Name == softwareName);
        }

        public void RemoveSoftware(string softwareName)
        {
            Software software = this.softwares.First(s => s.Name == softwareName);

            this.softwares.Remove(software);
            this.CapacityInUse -= software.CapacityConsumption;
            this.MemoryInUse -= software.MemoryConsumption;
        }

        public int GetSoftwaresCount()
        {
            return this.softwares.Count;
        }

        public int GetExpressSoftwareCount()
        {
            return this.softwares.Count(software => software.Type == "Express");
        }

        public int GetLightSoftwareCount()
        {
            return this.softwares.Count(software => software.Type == "Light");
        }

        public string GetSoftwaresName()
        {
            if (this.softwares.Count == 0)
            {
                return "None";
            }

            return string.Join(", ", this.softwares.Select(software => $"{software.Name}"));
        }
    }
}