namespace _01.SystemSplit.Core
{
    using Factories;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SystemManager
    {
        private Dictionary<string, Hardware> system;
        private Dictionary<string, Hardware> dump;

        public SystemManager()
        {
            this.system = new Dictionary<string, Hardware>();
            this.dump = new Dictionary<string, Hardware>();
        }

        public void RegisterPowerHardware(string[] inputArgs)
        {
            string hardwareName = inputArgs[0];
            const string type = "Power";
            int maximumCapacity = int.Parse(inputArgs[1]);
            int maximumMemory = int.Parse(inputArgs[2]);

            Hardware hardware = HardwareFactory.CreateHardware(hardwareName, type, maximumCapacity, maximumMemory);
            this.system[hardwareName] = hardware;
        }

        public void RegisterHeavyHardware(string[] inputArgs)
        {
            string type = "Heavy";
            string hardwareName = inputArgs[0];
            int maximumCapacity = int.Parse(inputArgs[1]);
            int maximumMemory = int.Parse(inputArgs[2]);

            Hardware hardware = HardwareFactory.CreateHardware(hardwareName, type, maximumCapacity, maximumMemory);
            this.system[hardwareName] = hardware;
        }

        public void RegisterExpressSoftware(string[] inputArgs)
        {
            string type = "Express";
            string hardwareName = inputArgs[0];
            string softwareName = inputArgs[1];
            int capacityConsumption = int.Parse(inputArgs[2]);
            int memoryConsumption = int.Parse(inputArgs[3]);

            Software software = SoftwareFactory.CreateSoftware(softwareName, type, capacityConsumption, memoryConsumption);

            if (this.system.ContainsKey(hardwareName))
            {
                if (this.system[hardwareName].CanSoftwareBeAdded(software))
                {
                    this.system[hardwareName].AddSoftware(software);
                }
            }
        }

        public void RegisterLightSoftware(string[] inputArgs)
        {
            string type = "Light";
            string hardwareName = inputArgs[0];
            string softwareName = inputArgs[1];
            int capacityConsumption = int.Parse(inputArgs[2]);
            int memoryConsumption = int.Parse(inputArgs[3]);

            Software software = SoftwareFactory.CreateSoftware(softwareName, type, capacityConsumption, memoryConsumption);

            if (this.system.ContainsKey(hardwareName))
            {
                if (this.system[hardwareName].CanSoftwareBeAdded(software))
                {
                    this.system[hardwareName].AddSoftware(software);
                }
            }
        }

        public string Analyze()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("System Analysis");
            sb.AppendLine($"Hardware Components: {this.system.Count}");
            sb.AppendLine($"Software Components: {this.system.Values.Sum(h => h.GetSoftwaresCount())}");
            sb.AppendLine($"Total Operational Memory: {this.system.Values.Sum(h => h.MemoryInUse)} / {this.system.Values.Sum(h => h.MaximumMemory)}");
            sb.AppendLine($"Total Capacity Taken: {this.system.Values.Sum(h => h.CapacityInUse)} / {this.system.Values.Sum(h => h.MaximumCapacity)}");

            return sb.ToString().Trim();
        }

        public void ReleaseSoftwareComponent(string[] inputArgs)
        {
            string hardwareName = inputArgs[0];
            string softwareName = inputArgs[1];

            if (this.system.ContainsKey(hardwareName))
            {
                if (this.system[hardwareName].IsSoftwareExisting(softwareName))
                {
                    this.system[hardwareName].RemoveSoftware(softwareName);
                }
            }
        }

        public void Dump(string[] inputArgs)
        {
            string hardwareName = inputArgs[0];

            if (this.system.ContainsKey(hardwareName))
            {
                Hardware hardware = this.system[hardwareName];

                this.dump[hardwareName] = hardware;
                this.system.Remove(hardwareName);
            }
        }

        public void Restore(string[] inputArgs)
        {
            string hardwareName = inputArgs[0];

            if (this.dump.ContainsKey(hardwareName))
            {
                Hardware hardware = this.dump[hardwareName];

                this.system[hardwareName] = hardware;
                this.dump.Remove(hardwareName);
            }
        }

        public void Destroy(string[] inputArgs)
        {
            string hardwareName = inputArgs[0];

            if (this.dump.ContainsKey(hardwareName))
            {
                this.dump.Remove(hardwareName);
            }
        }

        public string DumpAnalyze()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Dump Analysis");
            sb.AppendLine($"Power Hardware Components: {this.dump.Count(h => h.Value.Type == "Power")}");
            sb.AppendLine($"Heavy Hardware Components: {this.dump.Count(h => h.Value.Type == "Heavy")}");
            sb.AppendLine($"Express Software Components: {this.dump.Sum(h => h.Value.GetExpressSoftwareCount())}");
            sb.AppendLine($"Light Software Components: {this.dump.Sum(h => h.Value.GetLightSoftwareCount())}");
            sb.AppendLine($"Total Dumped Memory: {this.dump.Sum(h => h.Value.MemoryInUse)}");
            sb.AppendLine($"Total Dumped Capacity: {this.dump.Sum(h => h.Value.CapacityInUse)}");

            return sb.ToString().Trim();
        }

        public string GetSystemStats()
        {
            StringBuilder sb = new StringBuilder();

            this.GetHardwareInformation("Power", sb);
            this.GetHardwareInformation("Heavy", sb);

            return sb.ToString().Trim();
        }

        private void GetHardwareInformation(string type, StringBuilder sb)
        {
            foreach (Hardware hardware in this.system.Values.Where(h => h.Type == type))
            {
                sb.AppendLine($"Hardware Component - {hardware.Name}");
                sb.AppendLine($"Express Software Components - {this.system[hardware.Name].GetExpressSoftwareCount()}");
                sb.AppendLine($"Light Software Components - {this.system[hardware.Name].GetLightSoftwareCount()}");
                sb.AppendLine($"Memory Usage: {this.system[hardware.Name].MemoryInUse} / {this.system[hardware.Name].MaximumMemory}");
                sb.AppendLine($"Capacity Usage: {this.system[hardware.Name].CapacityInUse} / {this.system[hardware.Name].MaximumCapacity}");
                sb.AppendLine($"Type: {type}");
                sb.AppendLine($"Software Components: {this.system[hardware.Name].GetSoftwaresName()}");
            }
        }
    }
}