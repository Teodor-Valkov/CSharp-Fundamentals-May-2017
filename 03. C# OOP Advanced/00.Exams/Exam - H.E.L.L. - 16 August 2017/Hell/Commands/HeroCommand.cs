using System.Collections.Generic;

public class HeroCommand : AbstractCommand
{
    public HeroCommand(IList<string> tokens, IHeroManager heroManager)
        : base(tokens, heroManager)
    {
    }

    public override string Execute()
    {
        string heroName = this.Tokens[0];
        string heroType = this.Tokens[1];

        return this.HeroManager.CreateHero(heroName, heroType);
    }
}