using System.Collections.Generic;

public class Trainer
{
    private string name;
    private int badges;
    private List<Pokemon> pokemons;

    public Trainer(string name)
    {
        this.Name = name;
        this.Badges = 0;
        this.Pokemons = new List<Pokemon>();
    }

    public string Name
    {
        get { return this.name; }
        private set { this.name = value; }
    }

    public int Badges
    {
        get { return this.badges; }
        private set { this.badges = value; }
    }

    public List<Pokemon> Pokemons
    {
        get { return this.pokemons; }
        private set { this.pokemons = value; }
    }

    public void IncreaseBadges()
    {
        this.Badges++;
    }
}