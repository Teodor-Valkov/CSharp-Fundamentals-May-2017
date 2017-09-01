using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    private const string CommandSuffix = "Command";

    private IHeroManager heroManager;

    public CommandInterpreter(IHeroManager heroManager)
    {
        this.heroManager = heroManager;
    }

    public IExecutable InterpretCommand(IList<string> tokens)
    {
        string commandName = tokens[0];
        tokens.RemoveAt(0);

        // 1. The command is created with the help of the Activator
        // 2. The command can also be created with the help of the ConstructorInfo

        Type commandType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == commandName + CommandSuffix);
        //ConstructorInfo commandConstructor = commandType.GetConstructor(new Type[] { typeof(IList<string>), typeof(IHeroManager) });

        IExecutable command = null;

        try
        {
            command = (IExecutable)Activator.CreateInstance(commandType, new object[] { tokens, heroManager });
            //command = (IExecutable)commandConstructor.Invoke(new object[] { tokens, this.heroManager });
        }
        catch (InvalidOperationException)
        {
            throw new InvalidOperationException("Invalid command!");
        }

        return command;
    }
}