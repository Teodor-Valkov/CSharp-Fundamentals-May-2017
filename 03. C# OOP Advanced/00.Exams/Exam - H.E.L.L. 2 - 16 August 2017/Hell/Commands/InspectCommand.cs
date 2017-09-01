using System.Collections.Generic;

public class InspectCommand : Command
{
    [Inject]
    private IRepository repository;

    public InspectCommand(IList<string> tokens)
        : base(tokens)
    {
    }

    public override string Execute()
    {
        string heroName = this.Tokens[0];
        return this.repository.Inspect(heroName);
    }
}