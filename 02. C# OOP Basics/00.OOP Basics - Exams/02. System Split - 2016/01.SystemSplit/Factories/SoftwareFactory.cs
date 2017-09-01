namespace _01.SystemSplit.Factories
{
    using Models;
    using Models.Softwares;
    using System;

    public class SoftwareFactory
    {
        public static Software CreateSoftware(string name, string type, int capacityConsumption, int memoryConsumption)
        {
            switch (type)
            {
                case "Express":
                    return new ExpressSoftware(name, type, capacityConsumption, memoryConsumption);

                case "Light":
                    return new LightSoftware(name, type, capacityConsumption, memoryConsumption);

                default:
                    throw new ArgumentException();
            }
        }
    }
}