namespace RecyclingStation.Models.Station
{
    using Factory;
    using WasteDisposal;
    using WasteDisposal.Interfaces;

    public class RecyclingStationSystem
    {
        private double energyBalance;
        private double capitalBalance;
        private double minimumEnergyBalance;
        private double minimumCapitalBalance;
        private string garbageManagingType;
        private IGarbageProcessor garbagePorcessor;

        public RecyclingStationSystem()
        {
            this.garbagePorcessor = new GarbageProcessor();
        }

        public string ProcessGarbage(string[] input)
        {
            string name = input[0];
            double weight = double.Parse(input[1]);
            double volume = double.Parse(input[2]);
            string type = input[3];

            IWaste garbage = GarbageFactory.CreateGarbage(type, name, weight, volume);

            if (type == this.garbageManagingType)
            {
                if (this.minimumEnergyBalance > this.energyBalance || this.minimumCapitalBalance > this.capitalBalance)
                {
                    return "Processing Denied!";
                }
            }

            IProcessingData data = this.garbagePorcessor.ProcessWaste(garbage);

            this.energyBalance += data.EnergyBalance;
            this.capitalBalance += data.CapitalBalance;

            return $"{weight.ToString("0.00")} kg of {name} successfully processed!";
        }

        public string ChangeManagmentRequirement(string[] input)
        {
            double minimumEnergyBalance = double.Parse(input[0]);
            double minimumCapitalBalance = double.Parse(input[1]);
            string garbageType = input[2];

            this.minimumCapitalBalance = minimumCapitalBalance;
            this.minimumEnergyBalance = minimumEnergyBalance;
            this.garbageManagingType = garbageType;

            return "Management requirement changed!";
        }

        public string Status()
        {
            return $"Energy: {this.energyBalance.ToString("0.00")} Capital: {this.capitalBalance.ToString("0.00")}";
        }
    }
}