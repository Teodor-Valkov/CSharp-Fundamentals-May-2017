using System.Collections.Generic;

public class RecipeCommand : Command
{
    [Inject]
    private IFactory factory;

    [Inject]
    private IRepository repository;

    public RecipeCommand(IList<string> tokens)
        : base(tokens)
    {
    }

    public override string Execute()
    {
        string recipeName = this.Tokens[0];
        string heroName = this.Tokens[1];
        this.Tokens.RemoveAt(1);

        IRecipe recipe = this.factory.CreateObject<IRecipe>("RecipeItem", this.Tokens);
        this.repository.AddRecipe(heroName, recipe);

        return string.Format(Constants.RecipeCreatedMessage, recipeName, heroName);
    }
}