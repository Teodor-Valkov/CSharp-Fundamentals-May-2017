public class Amethyst : Gem, IGem
{
    public Amethyst(ClarityLevel clarityLevel)
        : base(clarityLevel)
    {
        this.Strength = Constants.AmethystStrength;
        this.Agility = Constants.AmethystAgility;
        this.Vitality = Constants.AmethystVitality;
        this.ModifyStats();
    }
}