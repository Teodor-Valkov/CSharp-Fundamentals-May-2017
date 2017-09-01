public abstract class Gem : IGem
{
    private int strength;
    private int agility;
    private int vitality;
    private ClarityLevel clarityLevel;

    protected Gem(ClarityLevel clarityLevel)
    {
        this.ClarityLevel = clarityLevel;
    }

    public int Strength
    {
        get { return this.strength; }
        protected set { this.strength = value; }
    }

    public int Agility
    {
        get { return this.agility; }
        protected set { this.agility = value; }
    }

    public int Vitality
    {
        get { return this.vitality; }
        protected set { this.vitality = value; }
    }

    public ClarityLevel ClarityLevel
    {
        get { return this.clarityLevel; }
        private set { this.clarityLevel = value; }
    }

    public virtual void ModifyStats()
    {
        switch (this.ClarityLevel)
        {
            case ClarityLevel.Chipped:
                this.Strength += (int)ClarityLevel.Chipped;
                this.Agility += (int)ClarityLevel.Chipped;
                this.Vitality += (int)ClarityLevel.Chipped;
                break;

            case ClarityLevel.Regular:
                this.Strength += (int)ClarityLevel.Regular;
                this.Agility += (int)ClarityLevel.Regular;
                this.Vitality += (int)ClarityLevel.Regular;
                break;

            case ClarityLevel.Perfect:
                this.Strength += (int)ClarityLevel.Perfect;
                this.Agility += (int)ClarityLevel.Perfect;
                this.Vitality += (int)ClarityLevel.Perfect;
                break;

            case ClarityLevel.Flawless:
                this.Strength += (int)ClarityLevel.Flawless;
                this.Agility += (int)ClarityLevel.Flawless;
                this.Vitality += (int)ClarityLevel.Flawless;
                break;
        }
    }
}