public class RetireCommand : Command, IExecutable
{
    public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
        : base(data, repository, unitFactory)
    {
    }

    public override string Execute()
    {
        string unitType = this.Data[0];
        return this.Repository.RemoveUnit(unitType);
    }
}