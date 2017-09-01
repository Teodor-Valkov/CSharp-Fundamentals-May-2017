namespace _01.Emergency.Contracts
{
    public interface ICommandInterpreter
    {
        IExecutable InterpretCommand(string input);
    }
}