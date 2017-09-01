using System;
using System.Reflection;

public class UnitFactory : IUnitFactory
{
    public IUnit CreateUnit(string unitType)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();

        Type type = assembly.GetType(unitType);
        //Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == unitType);
        //Type type = assembly.DefinedTypes.FirstOrDefault(t => t.Name == unitType);

        return (IUnit)Activator.CreateInstance(type);
    }
}