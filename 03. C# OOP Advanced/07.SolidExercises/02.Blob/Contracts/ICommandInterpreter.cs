namespace _02.Blob.Contracts
{
    public interface ICommandInterpreter
    {
        void InterpretCommand(string commandName, string[] data);
    }
}