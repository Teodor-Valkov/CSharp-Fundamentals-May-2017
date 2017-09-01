public class RetireCommand : Command, IExecutable
{
    [Inject]
    private IRepository repository;

    public RetireCommand(string[] data)
        : base(data)
    {
    }

    public override string Execute()
    {
        string unitType = this.Data[0];
        return this.repository.RemoveUnit(unitType);
    }
}