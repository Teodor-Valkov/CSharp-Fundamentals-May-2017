using System.Collections.Generic;

public class QuitCommand : AbstractCommand
{
    public QuitCommand(IList<string> tokens, IHeroManager heroManager)
        : base(tokens, heroManager)

    {
    }

    public override string Execute()
    {
        return this.HeroManager.Quit();
    }
}