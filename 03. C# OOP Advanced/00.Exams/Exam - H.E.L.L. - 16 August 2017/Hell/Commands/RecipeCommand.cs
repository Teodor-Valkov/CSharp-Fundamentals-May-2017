using System.Collections.Generic;
using System.Linq;

public class RecipeCommand : AbstractCommand
{
    public RecipeCommand(IList<string> tokens, IHeroManager heroManager)
        : base(tokens, heroManager)
    {
    }

    public override string Execute()
    {
        string itemName = this.Tokens[0];
        string heroName = this.Tokens[1];
        int strengthBonus = int.Parse(this.Tokens[2]);
        int agilityBonus = int.Parse(this.Tokens[3]);
        int intelligenceBonus = int.Parse(this.Tokens[4]);
        int hitPointsBonus = int.Parse(this.Tokens[5]);
        int damageBonus = int.Parse(this.Tokens[6]);
        List<string> requiredItems = this.Tokens.Skip(7).ToList();

        return this.HeroManager.AddRecipe(itemName, heroName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus, requiredItems);
    }
}