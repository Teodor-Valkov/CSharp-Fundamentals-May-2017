public class Pokemon
{
    private string name;
    private string type;

    public Pokemon(string name, string type)
    {
        this.Name = name;
        this.Type = type;
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
}