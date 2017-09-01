namespace _01.SystemSplit.Models
{
    public abstract class Software : Component
    {
        private int capacityConsumption;
        private int memoryConsumption;

        protected Software(string name, string type, int capacityConsumption, int memoryConsumption)
            : base(name, type)
        {
            this.capacityConsumption = capacityConsumption;
            this.memoryConsumption = memoryConsumption;
        }

        public int CapacityConsumption
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

        public int MemoryConsumption
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
    }
}