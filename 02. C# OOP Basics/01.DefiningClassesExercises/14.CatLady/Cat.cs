public abstract class Cat
{
    private string name;

    public string Name
    {
        get
        {
            return this.name;
        }
        protected set
        {
            this.name = value;
        }
    }
}