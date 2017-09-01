using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class HeroManager : IHeroManager
{
    private const string CommandSuffix = "Command";

    private IFactory factory;
    private IRepository repository;

    public HeroManager(IFactory factory, IRepository repository)
    {
        this.factory = factory;
        this.repository = repository;
    }

    public IExecutable InterpretCommand(List<string> tokens)
    {
        string commandName = tokens[0];
        tokens.RemoveAt(0);

        Type typeOfcommand = Type.GetType(commandName + CommandSuffix);
        IExecutable command = (IExecutable)Activator.CreateInstance(typeOfcommand, new object[] { tokens });

        this.InjectDependencies(command);
        return command;
    }

    private void InjectDependencies(IExecutable command)
    {
        FieldInfo[] heroManagerFields = typeof(HeroManager)
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

        FieldInfo[] commandFields = command.GetType()
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(f => f.GetCustomAttributes(typeof(InjectAttribute)) != null) //.Where(f => f.IsDefined(typeof(InjectAttribute)))
            .ToArray();

        foreach (FieldInfo commandField in commandFields)
        {
            if (heroManagerFields.Any(f => f.FieldType == commandField.FieldType))
            {
                commandField.SetValue(command, heroManagerFields.FirstOrDefault(f => f.FieldType == commandField.FieldType).GetValue(this));
            }
        }
    }
}