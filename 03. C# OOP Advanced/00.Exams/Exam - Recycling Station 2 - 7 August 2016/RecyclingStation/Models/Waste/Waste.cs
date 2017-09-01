namespace RecyclingStation.Models.Waste
{
    using WasteDisposal.Interfaces;

    public abstract class Waste : IWaste
    {
        private string name;
        private double volumePerKg;
        private double weight;

        protected Waste(string name, double volumePerKg, double weight)
        {
            this.Name = name;
            this.VolumePerKg = volumePerKg;
            this.Weight = weight;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }

        public double VolumePerKg
        {
            get
            {
                return this.volumePerKg;
            }
            private set
            {
                this.volumePerKg = value;
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                this.weight = value;
            }
        }

        public double GetTotalGarbageVolume()
        {
            return this.Weight * this.VolumePerKg;
        }
    }
}