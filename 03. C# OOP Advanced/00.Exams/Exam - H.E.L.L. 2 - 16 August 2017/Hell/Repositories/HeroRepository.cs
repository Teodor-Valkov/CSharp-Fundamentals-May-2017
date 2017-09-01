using System.Collections.Generic;

public class HeroRepository : IRepository
{
    public IDictionary<string, IHero> heroes;

    public HeroRepository(IDictionary<string, IHero> heroes)
    {
        this.heroes = heroes;
    }

    public IEnumerable<IHero> Heroes
    {
        get { return this.heroes.Values; }
    }

    public void CreateHero(IHero hero)
    {
        this.heroes[hero.Name] = hero;
    }

    public void AddItem(string heroName, IItem item)
    {
        this.heroes[heroName].Inventory.AddCommonItem(item);
    }

    public void AddRecipe(string heroName, IRecipe recipe)
    {
        this.heroes[heroName].Inventory.AddRecipeItem(recipe);
    }

    public string Inspect(string heroName)
    {
        return this.heroes[heroName].ToString();
    }
}