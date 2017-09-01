namespace Emergency.Contracts.Core
{
    using IO;
    using System.Collections.Generic;

    public interface ICommandInterpreter
    {
        IExecutable InterpretCommand(IList<string> parameters);
    }
}