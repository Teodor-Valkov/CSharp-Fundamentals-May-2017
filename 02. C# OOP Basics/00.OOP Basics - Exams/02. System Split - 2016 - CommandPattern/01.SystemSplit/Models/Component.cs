public abstract class Component
{
    private string type;
    private string name;

    protected Component(string type, string name)
    {
        this.Type = type;
        this.Name = name;
    }

    public string Type
    {
        get
        {
            return this.type;
        }
        private set
        {
            this.type = value;
        }
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