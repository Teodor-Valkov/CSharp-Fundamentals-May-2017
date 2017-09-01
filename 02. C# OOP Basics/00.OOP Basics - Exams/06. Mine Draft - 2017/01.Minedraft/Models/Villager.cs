public abstract class Villager
{
    private string id;

    protected Villager(string id)
    {
        this.id = id;
    }

    public string GetId()
    {
        return this.id;
    }
}