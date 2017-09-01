using System.Collections.Generic;

public abstract class AbstractCommand : IExecutable
{
    protected AbstractCommand(IList<string> tokens, IHeroManager heroManager)
    {
        this.Tokens = tokens;
        this.HeroManager = heroManager;
    }

    public IList<string> Tokens { get; private set; }

    protected IHeroManager HeroManager { get; private set; }

    public abstract string Execute();
}