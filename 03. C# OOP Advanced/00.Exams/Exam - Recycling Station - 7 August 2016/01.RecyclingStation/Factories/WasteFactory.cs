namespace _01.RecyclingStation.Factories
{
    using _01.RecyclingStation.Contracts.Factories;
    using _01.RecyclingStation.WasteDisposal.Interfaces;
    using System;
    using System.Linq;
    using System.Reflection;

    public class WasteFactory : IWasteFactory
    {
        private const string GarbageSuffix = "Garbage";

        public IWaste CreateGarbage(string name, double weight, double volumePerKg, string type)
        {
            string typeFullName = type + GarbageSuffix;

            Type typeOfGarbageToActivate = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name.ToLower() == typeFullName.ToLower());
            //Type typeOfGarbageToActivate = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name.Equals(typeFullName, StringComparison.OrdinalIgnoreCase));

            return (IWaste)Activator.CreateInstance(typeOfGarbageToActivate, new object[] { name, weight, volumePerKg });
        }
    }
}