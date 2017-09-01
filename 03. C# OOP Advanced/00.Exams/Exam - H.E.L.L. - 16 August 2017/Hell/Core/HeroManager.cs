using Hell.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HeroManager : IHeroManager
{
    private IItemFactory itemFactory;
    private IDictionary<string, IHero> heroes;

    public HeroManager(IItemFactory itemFactory)
    {
        this.itemFactory = itemFactory;
        this.heroes = new Dictionary<string, IHero>();
    }

    public string CreateHero(string name, string type)
    {
        try
        {
            // 1. The hero is created with the help of the Activator
            // 2. The hero can also be created with the help of the ConstructorInfo

            Type typeOfHero = Type.GetType(type);

            IHero hero = (IHero)Activator.CreateInstance(typeOfHero, new object[] { name });

            //ConstructorInfo constructorOfHero = typeOfHero.GetConstructors().FirstOrDefault();
            //IHero hero = (IHero)constructorOfHero.Invoke(new object[] { name });

            this.heroes[name] = hero;

            return string.Format(Constants.HeroCreatedMessage, type, name);
        }
        catch (Exception)
        {
            return "Exception in HeroManager.cs -> CreateHero()";
        }
    }

    public string AddItem(string name, string heroName, int strengthBonus, int agilityBonus, int intelligenceBonus, int hitPointsBonus, int damageBonus)
    {
        try
        {
            IItem item = this.itemFactory.CreateItem(name, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus);

            this.heroes[heroName].Inventory.AddCommonItem(item);

            return string.Format(Constants.ItemCreatedMessage, item.Name, heroName);
        }
        catch (Exception)
        {
            return "Exception in HeroManager.cs -> AddItem()";
        }
    }

    public string AddRecipe(string name, string heroName, int strengthBonus, int agilityBonus, int intelligenceBonus, int hitPointsBonus, int damageBonus, IList<string> requiredItems)
    {
        try
        {
            IRecipe recipe = this.itemFactory.CreateRecipe(name, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus, requiredItems);

            this.heroes[heroName].Inventory.AddRecipeItem(recipe);

            return string.Format(Constants.RecipeCreatedMessage, recipe.Name, heroName);
        }
        catch (Exception)
        {
            return "Exception in HeroManager.cs -> AddRecipe()";
        }
    }

    public string InspectHero(string name)
    {
        try
        {
            return this.heroes[name].ToString();
        }
        catch (Exception)
        {
            return "Exception in HeroManager.cs -> Inspect()";
        }
    }

    public string Quit()
    {
        try
        {
            StringBuilder sb = new StringBuilder();
            int counter = 1;

            foreach (KeyValuePair<string, IHero> currentHero in heroes.OrderByDescending(h => h.Value.PrimaryStats).ThenByDescending(h => h.Value.SecondaryStats))
            {
                IHero hero = currentHero.Value;

                sb.AppendLine($"{counter++}. {hero.GetType()}: {hero.Name}");
                sb.AppendLine($"###HitPoints: {hero.HitPoints}");
                sb.AppendLine($"###Damage: {hero.Damage}");
                sb.AppendLine($"###Strength: {hero.Strength}");
                sb.AppendLine($"###Agility: {hero.Agility}");
                sb.AppendLine($"###Intelligence: {hero.Intelligence}");
                sb.AppendLine(hero.Items.Count == 0 ?
                    $"###Items: None" :
                    $"###Items: {string.Join(", ", hero.Items.Select(i => i.Name))}"); sb.Append($"###Items: ");
            }

            return sb.ToString().Trim();
        }
        catch (Exception)
        {
            return "Exception in HeroManager.cs -> Quit()";
        }
    }
}