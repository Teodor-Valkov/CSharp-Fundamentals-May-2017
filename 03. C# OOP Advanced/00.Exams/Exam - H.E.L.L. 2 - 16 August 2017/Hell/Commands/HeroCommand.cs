using System.Collections.Generic;

public class HeroCommand : Command
{
    [Inject]
    private IRepository repository;

    [Inject]
    private IFactory factory;

    public HeroCommand(IList<string> tokens)
        : base(tokens)
    {
    }

    public override string Execute()
    {
        string heroName = this.Tokens[0];
        string heroType = this.Tokens[1];
        this.Tokens.RemoveAt(1);

        IHero hero = this.factory.CreateObject<IHero>(heroType, this.Tokens);
        this.repository.CreateHero(hero);

        return string.Format(Constants.HeroCreateMessage, heroType, heroName);
    }
}