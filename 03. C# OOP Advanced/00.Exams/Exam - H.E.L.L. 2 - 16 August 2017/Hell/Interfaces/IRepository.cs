using System.Collections.Generic;

public interface IRepository
{
    IEnumerable<IHero> Heroes { get; }

    void CreateHero(IHero hero);

    void AddItem(string heroName, IItem item);

    void AddRecipe(string heroName, IRecipe recipe);

    string Inspect(string heroName);
}