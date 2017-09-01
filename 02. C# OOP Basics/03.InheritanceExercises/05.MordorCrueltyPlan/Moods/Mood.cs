public abstract class Mood
{
    private string name;

    protected Mood(string name)
    {
        this.Name = name;
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            this.name = value;
        }
    }
}