using System;
using System.Reflection;

public class UnitFactory : IUnitFactory
{
    public IUnit CreateUnit(string unitType)
    {
        Type typeOfUnit = Assembly.GetExecutingAssembly().GetType(unitType);
        //Type typeOfUnit = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == unitType);
        //Type typeOfUnit = Assembly.GetExecutingAssembly().DefinedTypes.FirstOrDefault(t => t.Name == unitType);

        return (IUnit)Activator.CreateInstance(typeOfUnit);
    }
}