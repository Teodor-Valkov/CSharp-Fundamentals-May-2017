using System;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    private IRepository repository;
    private IUnitFactory unitFactory;

    public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
    {
        this.repository = repository;
        this.unitFactory = unitFactory;
    }

    public IExecutable InterpretCommand(string commandName, string[] data)
    {
        try
        {
            Type commandType = Assembly.GetExecutingAssembly().DefinedTypes.FirstOrDefault(t => t.Name.ToLower() == commandName.ToLower() + "command");

            IExecutable command = null;

            try
            {
                command = (IExecutable)Activator.CreateInstance(commandType, new object[] { data });
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            this.InjectDependencies(command);
            return command;

            //Working through object => Get an object instance of command class and then the method called “Execute” of the command
            //
            //object command = Activator.CreateInstance(commandType, new object[] { data, this.repository, this.unitFactory });
            //MethodInfo executeMethod = command.GetType().GetMethod("Execute");
            //
            //return executeMethod.Invoke(command, new object[] { }).ToString();
        }
        catch (Exception)
        {
            throw new InvalidOperationException("Invalid command!");
        }
    }

    private void InjectDependencies(IExecutable command)
    {
        FieldInfo[] commandInterpreterFields = typeof(CommandInterpreter)
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

        FieldInfo[] commandFields = command
            .GetType()
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .Where(f => f.GetCustomAttribute(typeof(InjectAttribute)) != null)
            .ToArray();

        foreach (FieldInfo commandField in commandFields)
        {
            if (commandInterpreterFields.Any(f => f.FieldType == commandField.FieldType))
            {
                commandField.SetValue(command, commandInterpreterFields.First(f => f.FieldType == commandField.FieldType).GetValue(this));
            }
        }
    }
}