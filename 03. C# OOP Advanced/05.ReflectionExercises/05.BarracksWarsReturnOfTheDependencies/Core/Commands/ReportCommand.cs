public class ReportCommand : Command, IExecutable
{
    [Inject]
    private IRepository repository;

    public ReportCommand(string[] data)
        : base(data)
    {
    }

    public override string Execute()
    {
        return this.repository.GetStatistics();
    }
}