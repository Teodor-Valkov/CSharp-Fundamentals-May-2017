public class StreetExtraordinaire : Cat
{
    private int decibels;

    public StreetExtraordinaire(string name, int decibels)
    {
        this.Name = name;
        this.Decibels = decibels;
    }

    public int Decibels
    {
        get
        {
            return this.decibels;
        }
        private set
        {
            this.decibels = value;
        }
    }

    public override string ToString()
    {
        return $"{this.GetType()} {this.Name} {this.Decibels}";
    }
}