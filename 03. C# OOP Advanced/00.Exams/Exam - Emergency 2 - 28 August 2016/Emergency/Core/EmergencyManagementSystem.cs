namespace Emergency.Core
{
    using Collection;
    using Contracts.Collection;
    using Contracts.Core;
    using Contracts.Models.Emergencies;
    using Contracts.Models.EmergencyCenters;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class EmergencyManagementSystem : IManagementSystem
    {
        private const string Property = "Property";
        private const string Health = "Health";
        private const string Order = "Order";
        private const string Fire = "Fire";
        private const string Medical = "Medical";
        private const string Police = "Police";

        private int totalProcessedEmergencies;
        private IDictionary<string, IRegister<IEmergency>> emergencies;
        private IDictionary<string, IRegister<IEmergencyCenter>> centers;
        private IDictionary<string, long> processedEmergencies;

        public EmergencyManagementSystem()
        {
            this.InitEmergencies();
            this.InitCenters();
            this.InitProcessedEmergencies();
            this.totalProcessedEmergencies = 0;
        }

        private void InitProcessedEmergencies()
        {
            this.processedEmergencies = new Dictionary<string, long>();
            this.processedEmergencies[Property] = 0;
            this.processedEmergencies[Health] = 0;
            this.processedEmergencies[Order] = 0;
        }

        private void InitCenters()
        {
            this.centers = new Dictionary<string, IRegister<IEmergencyCenter>>();
            this.centers[Property] = new RegisterQueue<IEmergencyCenter>();
            this.centers[Health] = new RegisterQueue<IEmergencyCenter>();
            this.centers[Order] = new RegisterQueue<IEmergencyCenter>();
        }

        private void InitEmergencies()
        {
            this.emergencies = new Dictionary<string, IRegister<IEmergency>>();
            this.emergencies[Property] = new RegisterQueue<IEmergency>();
            this.emergencies[Health] = new RegisterQueue<IEmergency>();
            this.emergencies[Order] = new RegisterQueue<IEmergency>();
        }

        public string RegisterPropertyEmergency(IEmergency emergency)
        {
            this.emergencies[Property].Enqueue(emergency);
            return string.Format(emergency.ToString(), Property);
        }

        public string RegisterHealthEmergency(IEmergency emergency)
        {
            this.emergencies[Health].Enqueue(emergency);
            return string.Format(emergency.ToString(), Health);
        }

        public string RegisterOrderEmergency(IEmergency emergency)
        {
            this.emergencies[Order].Enqueue(emergency);
            return string.Format(emergency.ToString(), Order);
        }

        public string RegisterFireServiceCenter(IEmergencyCenter center)
        {
            this.centers[Property].Enqueue(center);
            return string.Format(center.ToString(), Fire);
        }

        public string RegisterMedicalServiceCenter(IEmergencyCenter center)
        {
            this.centers[Health].Enqueue(center);
            return string.Format(center.ToString(), Medical);
        }

        public string RegisterPoliceServiceCenter(IEmergencyCenter center)
        {
            this.centers[Order].Enqueue(center);
            return string.Format(center.ToString(), Police);
        }

        public string ProcessEmergencies(string type)
        {
            while (this.emergencies[type].Count != 0)
            {
                if (this.centers[type].Count == 0)
                {
                    return string.Format($"{type} Emergencies left to process: {this.emergencies[type].Count}.");
                }

                IEmergency currentEmergency = this.emergencies[type].Dequeue();
                this.processedEmergencies[type] += this.centers[type].Peek().ProcessEmergency(currentEmergency);

                if (this.centers[type].Peek().IsForRetirement())
                {
                    this.centers[type].Dequeue();
                }

                this.totalProcessedEmergencies++;
            }

            return string.Format($"Successfully responded to all {type} emergencies.");
        }

        public string EmergencyReport()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"PRRM Services Live Statistics");
            sb.AppendLine($"Fire Service Centers: {this.centers[Property].Count}");
            sb.AppendLine($"Medical Service Centers: {this.centers[Health].Count}");
            sb.AppendLine($"Police Service Centers: {this.centers[Order].Count}");
            sb.AppendLine($"Total Processed Emergencies: {this.totalProcessedEmergencies}");
            sb.AppendLine($"Currently Registered Emergencies: {this.emergencies.Sum(e => e.Value.Count)}");
            sb.AppendLine($"Total Property Damage Fixed: {this.processedEmergencies[Property]}");
            sb.AppendLine($"Total Health Casualties Saved: {this.processedEmergencies[Health]}");
            sb.AppendLine($"Total Special Cases Processed: {this.processedEmergencies[Order]}");

            return sb.ToString().Trim();
        }
    }
}