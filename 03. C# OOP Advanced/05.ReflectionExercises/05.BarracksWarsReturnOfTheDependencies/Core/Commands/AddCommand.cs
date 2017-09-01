public class AddCommand : Command, IExecutable
{
    [Inject]
    private IRepository repository;

    [Inject]
    private IUnitFactory unitFactory;

    public AddCommand(string[] data)
        : base(data)
    {
    }

    public override string Execute()
    {
        string unitType = this.Data[0];
        IUnit unitToAdd = this.unitFactory.CreateUnit(unitType);
        this.repository.AddUnit(unitToAdd);

        return $"{unitType} added!";
    }
}