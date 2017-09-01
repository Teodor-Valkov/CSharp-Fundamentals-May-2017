using System.Collections.Generic;

public abstract class Command : IExecutable
{
    protected Command(IList<string> tokens)
    {
        this.Tokens = tokens;
    }

    public IList<string> Tokens { get; private set; }

    public abstract string Execute();
}