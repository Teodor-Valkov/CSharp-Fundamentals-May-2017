namespace RecyclingStation.Factory
{
    using System;
    using System.Linq;
    using System.Reflection;
    using WasteDisposal.Interfaces;

    public static class GarbageFactory
    {
        public static IWaste CreateGarbage(string type, string name, double weight, double volume)
        {
            Type garbageType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == type + "Garbage");

            if (garbageType == null)
            {
                throw new ArgumentException("Invalid garbage type!");
            }

            return (IWaste)Activator.CreateInstance(garbageType, new object[] { name, volume, weight });
        }
    }
}