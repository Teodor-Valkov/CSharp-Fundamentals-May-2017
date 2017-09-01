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
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type commandType = assembly.DefinedTypes.FirstOrDefault(t => t.Name.ToLower() == commandName.ToLower() + "command");

            if (commandType == null)
            {
                throw new NotSupportedException($"Command {commandName} not supported!");
            }

            IExecutable command = (IExecutable)Activator.CreateInstance(commandType, new object[] { data, this.repository, this.unitFactory });
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
}