public class Ruby : Gem, IGem
{
    public Ruby(ClarityLevel clarityLevel)
        : base(clarityLevel)
    {
        this.Strength = Constants.RubyStrength;
        this.Agility = Constants.RubyAgility;
        this.Vitality = Constants.RubyVitality;
        this.ModifyStats();
    }
}