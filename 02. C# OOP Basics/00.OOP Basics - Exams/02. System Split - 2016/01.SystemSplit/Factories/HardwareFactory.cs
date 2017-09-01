namespace _01.SystemSplit.Factories
{
    using Models;
    using Models.Hardwares;
    using System;

    public class HardwareFactory
    {
        public static Hardware CreateHardware(string name, string type, int maximumCapacity, int maximumMemory)
        {
            switch (type)
            {
                case "Power":
                    return new PowerHardware(name, type, maximumCapacity, maximumMemory);

                case "Heavy":
                    return new HeavyHardware(name, type, maximumCapacity, maximumMemory);

                default:
                    throw new ArgumentException();
            }
        }
    }
}