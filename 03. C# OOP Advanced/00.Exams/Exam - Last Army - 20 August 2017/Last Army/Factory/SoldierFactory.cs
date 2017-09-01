using System;
using System.Linq;
using System.Reflection;

public class SoldierFactory : ISoldierFactory
{
    public ISoldier CreateSoldier(string soldierTypeName, string name, int age, double experience, double endurance)
    {
        Type typeOfSoldier = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == soldierTypeName);

        return (ISoldier)Activator.CreateInstance(typeOfSoldier, new object[] { name, age, experience, endurance });
    }
}