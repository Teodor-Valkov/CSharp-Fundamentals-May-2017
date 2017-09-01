namespace _01.SystemSplit.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Repository
    {
        private Dictionary<string, Hardware> hardware;
        private Dictionary<string, Hardware> dumpedHardware;

        public Repository()
        {
            this.hardware = new Dictionary<string, Hardware>();
            this.dumpedHardware = new Dictionary<string, Hardware>();
        }

        public IReadOnlyDictionary<string, Hardware> Hardware
        {
            get
            {
                return this.hardware;
            }
        }

        public IReadOnlyDictionary<string, Hardware> DumpedHardware
        {
            get
            {
                return this.dumpedHardware;
            }
        }

        public void AddHardware(Hardware hardware)
        {
            this.hardware.Add(hardware.Name, hardware);
        }

        public void ReleaseSoftware(string softwareName)
        {
            this.hardware.First(h => h.Value.Softwares.Any(s => s.Name == softwareName)).Value.RemoveSoftware(softwareName);
        }

        public void Dump(string hardwareName)
        {
            if (this.Hardware.ContainsKey(hardwareName))
            {
                Hardware hardwareForDump = this.Hardware[hardwareName];

                this.dumpedHardware[hardwareName] = hardwareForDump;
                this.hardware.Remove(hardwareName);
            }
        }

        public void Restore(string hardwareName)
        {
            if (this.DumpedHardware.ContainsKey(hardwareName))
            {
                Hardware hardwareForRestore = this.dumpedHardware[hardwareName];

                this.hardware[hardwareName] = hardwareForRestore;
                this.dumpedHardware.Remove(hardwareName);
            }
        }

        public void Destroy(string hardwareName)
        {
            if (this.DumpedHardware.ContainsKey(hardwareName))
            {
                this.dumpedHardware.Remove(hardwareName);
            }
        }

        public void PrintAnalyze()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("System Analysis");
            sb.AppendLine($"Hardware Components: {this.Hardware.Count}");
            sb.AppendLine($"Software Components: {this.Hardware.Values.Select(h => h.Softwares.Count).Sum()}");
            sb.AppendLine($"Total Operational Memory: {this.Hardware.Sum(h => h.Value.MemoryInUse)} / {this.Hardware.Sum(h => h.Value.MaxMemory)}");
            sb.Append($"Total Capacity Taken: {this.Hardware.Sum(h => h.Value.CapacityInUse)} / {this.Hardware.Sum(h => h.Value.MaxCapacity)}");

            Console.WriteLine(sb.ToString());
        }

        public void PrintDumpAnalyze()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Dump Analysis");
            sb.AppendLine($"Power Hardware Components: {this.DumpedHardware.Count(h => h.Value.Type == "Power")}");
            sb.AppendLine($"Heavy Hardware Components: {this.DumpedHardware.Count(h => h.Value.Type == "Heavy")}");
            sb.AppendLine($"Express Software Components: {this.dumpedHardware.Sum(h => h.Value.Softwares.Count(s => s.Type == "Express Software"))}");
            sb.AppendLine($"Light Software Components: {this.dumpedHardware.Sum(h => h.Value.Softwares.Count(s => s.Type == "Light Software"))}");
            sb.AppendLine($"Total Dumped Memory: {this.DumpedHardware.Values.Sum(h => h.MemoryInUse)}");
            sb.Append($"Total Dumped Capacity: {this.DumpedHardware.Values.Sum(h => h.CapacityInUse)}");

            Console.WriteLine(sb.ToString());
        }

        public void PrintSystemSplit()
        {
            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<string, Hardware> hardware in this.Hardware)
            {
                sb.AppendLine($"Hardware Component - {hardware.Key}");
                sb.AppendLine($"Express Software Components - {hardware.Value.Softwares.Count(s => s.Type == "Express Software")}");
                sb.AppendLine($"Light Software Components - {hardware.Value.Softwares.Count(s => s.Type == "Light Software")}");
                sb.AppendLine($"Memory Usage: {hardware.Value.MemoryInUse} / {hardware.Value.MaxMemory}");
                sb.AppendLine($"Capacity Usage: {hardware.Value.CapacityInUse} / {hardware.Value.MaxCapacity}");
                sb.AppendLine($"Type: {hardware.Value.Type}");
                sb.Append(hardware.Value.Softwares.Count == 0
                    ? "Software Components: None"
                    : $"Software Components: {string.Join(", ", hardware.Value.Softwares)}");

                Console.WriteLine(sb.ToString());
                sb.Clear();
            }
        }
    }
}