using System.Collections.Generic;

public interface IHeroManager
{
    string CreateHero(string name, string type);

    string AddItem(string name, string heroName, int strengthBonus, int agilityBonus, int intelligenceBonus, int hitPointsBonus, int damageBonus);

    string AddRecipe(string name, string heroName, int strengthBonus, int agilityBonus, int intelligenceBonus, int hitPointsBonus, int damageBonus, IList<string> requiredItems);

    string InspectHero(string name);

    string Quit();
}