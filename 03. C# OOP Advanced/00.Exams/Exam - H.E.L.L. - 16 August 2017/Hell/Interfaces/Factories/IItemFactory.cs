using System.Collections.Generic;

namespace Hell.Interfaces
{
    public interface IItemFactory
    {
        IItem CreateItem(string name, int strengthBonus, int agilityBonus, int intelligenceBonus, int hitPointsBonus, int damageBonus);

        IRecipe CreateRecipe(string name, int strengthBonus, int agilityBonus, int intelligenceBonus, int hitPointsBonus, int damageBonus, IList<string> requiredItems);
    }
}