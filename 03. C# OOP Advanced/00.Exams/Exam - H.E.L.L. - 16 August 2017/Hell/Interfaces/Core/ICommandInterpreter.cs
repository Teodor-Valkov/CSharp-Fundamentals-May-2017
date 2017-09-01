using System.Collections.Generic;

public interface ICommandInterpreter
{
    IExecutable InterpretCommand(IList<string> tokens);
}