public class Emerald : Gem, IGem
{
    public Emerald(ClarityLevel clarityLevel)
        : base(clarityLevel)
    {
        this.Strength = Constants.EmeraldStrength;
        this.Agility = Constants.EmeraldAgility;
        this.Vitality = Constants.EmeraldVitality;
        this.ModifyStats();
    }
}