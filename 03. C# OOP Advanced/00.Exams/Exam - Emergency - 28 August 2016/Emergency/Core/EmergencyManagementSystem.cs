namespace _01.Emergency.Core
{
    using _01.Emergency.Collection;
    using _01.Emergency.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class EmergencyManagementSystem : IEmergencyManagementSystem
    {
        private const string Property = "Property";
        private const string Health = "Health";
        private const string Order = "Order";
        private const string Fire = "Fire";
        private const string Medical = "Medical";
        private const string Police = "Police";
        private const long InitialValue = 0L;
        private const string RegisteredPublicEmergencyOfLevel = "Registered Public {0} Emergency of level {1} at {2}.";
        private const string RegisteredServiceEmergencyCenter = "Registered {0} Service Emergency Center - {1}.";

        private IDictionary<string, IEmergencyRegister<IEmergency>> emergencies;
        private IDictionary<string, IEmergencyRegister<IEmergencyCenter>> centers;
        private IDictionary<string, long> resultsOfProcessedEmergencies;
        private int totalProcessedEmergencies;

        public EmergencyManagementSystem()
        {
            this.InitializeEmergenciesCollection();
            this.InitializeCentersCollection();
            this.InitializeResultsCollection();
            this.totalProcessedEmergencies = 0;
        }

        private void InitializeEmergenciesCollection()
        {
            this.emergencies = new Dictionary<string, IEmergencyRegister<IEmergency>>();
            this.emergencies[Property] = new EmergencyRegister<IEmergency>();
            this.emergencies[Health] = new EmergencyRegister<IEmergency>();
            this.emergencies[Order] = new EmergencyRegister<IEmergency>();
        }

        private void InitializeCentersCollection()
        {
            this.centers = new Dictionary<string, IEmergencyRegister<IEmergencyCenter>>();
            this.centers[Property] = new EmergencyRegister<IEmergencyCenter>();
            this.centers[Health] = new EmergencyRegister<IEmergencyCenter>();
            this.centers[Order] = new EmergencyRegister<IEmergencyCenter>();
        }

        private void InitializeResultsCollection()
        {
            this.resultsOfProcessedEmergencies = new Dictionary<string, long>();
            this.resultsOfProcessedEmergencies[Property] = InitialValue;
            this.resultsOfProcessedEmergencies[Health] = InitialValue;
            this.resultsOfProcessedEmergencies[Order] = InitialValue;
        }

        public string RegisterPropertyEmergency(IEmergency emergency)
        {
            this.emergencies[Property].EnqueueEmergency(emergency);

            return string.Format(RegisteredPublicEmergencyOfLevel, Property, emergency.EmergencyLevel, emergency.RegistrationTime);
        }

        public string RegisterHealthEmergency(IEmergency emergency)
        {
            this.emergencies[Health].EnqueueEmergency(emergency);

            return string.Format(RegisteredPublicEmergencyOfLevel, Health, emergency.EmergencyLevel, emergency.RegistrationTime);
        }

        public string RegisterOrderEmergency(IEmergency emergency)
        {
            this.emergencies[Order].EnqueueEmergency(emergency);

            return string.Format(RegisteredPublicEmergencyOfLevel, Order, emergency.EmergencyLevel, emergency.RegistrationTime);
        }

        public string RegisterFireServiceCenter(IEmergencyCenter emergencyCenter)
        {
            this.centers[Property].EnqueueEmergency(emergencyCenter);

            return string.Format(RegisteredServiceEmergencyCenter, Fire, emergencyCenter.Name);
        }

        public string RegisterMedicalServiceCenter(IEmergencyCenter emergencyCenter)
        {
            this.centers[Health].EnqueueEmergency(emergencyCenter);

            return string.Format(RegisteredServiceEmergencyCenter, Medical, emergencyCenter.Name);
        }

        public string RegisterPoliceServiceCenter(IEmergencyCenter emergencyCenter)
        {
            this.centers[Order].EnqueueEmergency(emergencyCenter);

            return string.Format(RegisteredServiceEmergencyCenter, Police, emergencyCenter.Name);
        }

        public string ProcessEmergencies(string type)
        {
            IEmergencyRegister<IEmergency> emergenciesToProcess = this.emergencies[type];
            IEmergencyRegister<IEmergencyCenter> processCenters = this.centers[type];

            while (emergenciesToProcess.Count() != 0)
            {
                if (processCenters.Count() == 0)
                {
                    return string.Format($"{type} Emergencies left to process: {emergenciesToProcess.Count()}.");
                }

                IEmergencyCenter currentCenter = processCenters.DequeueEmergency();

                if (currentCenter.IsForRetirement())
                {
                    continue;
                }

                IEmergency currentEmergency = emergenciesToProcess.DequeueEmergency();

                long currentResult = this.resultsOfProcessedEmergencies[type];
                this.resultsOfProcessedEmergencies[type] = currentResult + currentEmergency.GetResultAfterProcessing();

                currentCenter.ProcessEmergency();
                processCenters.EnqueueEmergency(currentCenter);

                this.totalProcessedEmergencies++;
            }

            return string.Format($"Successfully responded to all {type} emergencies.");
        }

        public string EmergencyReport()
        {
            foreach (IEmergencyRegister<IEmergencyCenter> centerRegister in this.centers.Values)
            {
                IList<IEmergencyCenter> temp = new List<IEmergencyCenter>();

                while (centerRegister.Count() != 0)
                {
                    IEmergencyCenter currentCenter = centerRegister.DequeueEmergency();

                    if (currentCenter.IsForRetirement())
                    {
                        continue;
                    }

                    temp.Add(currentCenter);
                }

                foreach (IEmergencyCenter emergencyCenter in temp)
                {
                    centerRegister.EnqueueEmergency(emergencyCenter);
                }
            }

            int allRegisteredEmergencies = this.emergencies.Sum(em => em.Value.Count());

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format($"PRRM Services Live Statistics"));
            sb.AppendLine(string.Format($"Fire Service Centers: {this.centers[Property].Count()}"));
            sb.AppendLine(string.Format($"Medical Service Centers: {this.centers[Health].Count()}"));
            sb.AppendLine(string.Format($"Police Service Centers: {this.centers[Order].Count()}"));
            sb.AppendLine(string.Format($"Total Processed Emergencies: {this.totalProcessedEmergencies}"));
            sb.AppendLine(string.Format($"Currently Registered Emergencies: {allRegisteredEmergencies}"));
            sb.AppendLine(string.Format($"Total Property Damage Fixed: {this.resultsOfProcessedEmergencies[Property]}"));
            sb.AppendLine(string.Format($"Total Health Casualties Saved: {this.resultsOfProcessedEmergencies[Health]}"));
            sb.AppendLine(string.Format($"Total Special Cases Processed: {this.resultsOfProcessedEmergencies[Order]}"));

            return sb.ToString().Trim();
        }
    }
}