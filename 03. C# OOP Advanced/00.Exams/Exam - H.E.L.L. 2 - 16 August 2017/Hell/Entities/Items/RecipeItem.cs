using System.Collections.Generic;
using System.Linq;

public class RecipeItem : Item, IRecipe
{
    public RecipeItem(string name, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitPointsBonus, long damageBonus, List<string> requiredItems)
        : base(name, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus)
    {
        this.RequiredItems = requiredItems.ToList();
    }

    public IList<string> RequiredItems { get; }
}