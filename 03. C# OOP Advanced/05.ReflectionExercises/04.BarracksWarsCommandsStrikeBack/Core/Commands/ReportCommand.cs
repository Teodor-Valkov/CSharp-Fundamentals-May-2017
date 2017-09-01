public class ReportCommand : Command, IExecutable
{
    public ReportCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
        : base(data, repository, unitFactory)
    {
    }

    public override string Execute()
    {
        return this.Repository.GetStatistics();
    }
}