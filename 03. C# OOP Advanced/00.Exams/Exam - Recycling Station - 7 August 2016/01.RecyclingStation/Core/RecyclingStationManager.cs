namespace _01.RecyclingStation.Core
{
    using _01.RecyclingStation.Contracts.Core;
    using _01.RecyclingStation.Contracts.Factories;
    using _01.RecyclingStation.WasteDisposal.Interfaces;

    public class RecyclingStationManager : IRecyclingStationManager
    {
        private const string ManagementRequirementsMessage = "Management requirement changed!";
        private const string ProcessingDeniedMessage = "Processing Denied!";
        private const string StatusMessageFormat = "Energy: {0} Capital: {1}";
        private const string ProcessedGarbageMessageFormat = "{0} kg of {1} successfully processed!";
        private const string FloatingPointNumberFormat = "F2";

        private IGarbageProcessor garbageProcessor;
        private IWasteFactory wasteFactory;

        private double capitalBalance;
        private double energyBalance;

        private double minimumCapitalBalance;
        private double minimumEnergyBalance;
        private string typeOfGarbage;
        private bool areThereManagementRequirements;

        public RecyclingStationManager(IGarbageProcessor garbageProcessor, IWasteFactory wasteFactory)
        {
            this.garbageProcessor = garbageProcessor;
            this.wasteFactory = wasteFactory;
        }

        public string ProcessGarbage(string name, double weight, double volumePerKg, string type)
        {
            if (this.areThereManagementRequirements)
            {
                bool areManagementRequirementsSatisfied = true;
                if (this.typeOfGarbage == type)
                {
                    areManagementRequirementsSatisfied = this.capitalBalance >= this.minimumCapitalBalance && this.energyBalance >= this.minimumEnergyBalance;
                }

                if (!areManagementRequirementsSatisfied)
                {
                    return ProcessingDeniedMessage;
                }
            }

            IWaste garbage = this.wasteFactory.CreateGarbage(name, weight, volumePerKg, type);

            IProcessingData processingData = this.garbageProcessor.ProcessWaste(garbage);
            this.capitalBalance += processingData.CapitalBalance;
            this.energyBalance += processingData.EnergyBalance;

            string formattedMessage = string.Format(ProcessedGarbageMessageFormat,
                                                    garbage.Weight.ToString(FloatingPointNumberFormat),
                                                    garbage.Name);

            return formattedMessage;
        }

        public string Status()
        {
            string formattedMessage = string.Format(StatusMessageFormat,
                                                    this.energyBalance.ToString(FloatingPointNumberFormat),
                                                    this.capitalBalance.ToString(FloatingPointNumberFormat));

            return formattedMessage;
        }

        public string ChangeManagementRequirement(double minimumEnergyBalance, double minimumCapitalBalance, string typeOfGarbage)
        {
            this.minimumEnergyBalance = minimumEnergyBalance;
            this.minimumCapitalBalance = minimumCapitalBalance;
            this.typeOfGarbage = typeOfGarbage;
            this.areThereManagementRequirements = true;

            return ManagementRequirementsMessage;
        }
    }
}