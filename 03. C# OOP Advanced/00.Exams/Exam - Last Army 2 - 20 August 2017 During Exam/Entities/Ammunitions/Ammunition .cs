public abstract class Ammunition : IAmmunition
{
    protected Ammunition(string name)
    {
        this.Name = name;
    }

    public string Name { get; private set; }

    public double Weight { get; protected set; }

    public double WearLevel { get; protected set; }

    public void DecreaseWearLevel(double wearAmount)
    {
        this.WearLevel -= wearAmount;
    }
}