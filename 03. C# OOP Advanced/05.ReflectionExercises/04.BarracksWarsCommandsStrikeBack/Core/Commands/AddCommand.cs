public class AddCommand : Command, IExecutable
{
    public AddCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
        : base(data, repository, unitFactory)
    {
    }

    public override string Execute()
    {
        string unitType = this.Data[0];
        IUnit unitToAdd = this.UnitFactory.CreateUnit(unitType);

        this.Repository.AddUnit(unitToAdd);
        return $"{unitType} added!";
    }
}