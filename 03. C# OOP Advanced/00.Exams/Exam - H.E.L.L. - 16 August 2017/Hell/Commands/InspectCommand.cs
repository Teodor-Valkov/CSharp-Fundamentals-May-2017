using System.Collections.Generic;

public class InspectCommand : AbstractCommand
{
    public InspectCommand(IList<string> tokens, IHeroManager heroManager)
        : base(tokens, heroManager)
    {
    }

    public override string Execute()
    {
        string heroName = this.Tokens[0];

        return this.HeroManager.InspectHero(heroName);
    }
}