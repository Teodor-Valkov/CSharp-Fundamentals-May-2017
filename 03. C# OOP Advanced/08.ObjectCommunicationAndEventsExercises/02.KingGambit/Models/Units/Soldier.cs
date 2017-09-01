public abstract class Soldier : ISoldier
{
    public Soldier(string name)
    {
        this.Name = name;
    }

    public string Name { get; private set; }
}