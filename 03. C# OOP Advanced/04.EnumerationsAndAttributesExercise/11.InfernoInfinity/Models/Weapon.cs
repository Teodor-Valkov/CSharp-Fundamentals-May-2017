using System.Linq;

public abstract class Weapon : IWeapon
{
    private string name;
    private int minDamage;
    private int maxDamage;
    private int sockets;
    private RarityLevel rarityLevel;
    private IGem[] gems;

    protected Weapon(string name, RarityLevel rarityLevel)
    {
        this.Name = name;
        this.RarityLevel = rarityLevel;
    }

    public string Name
    {
        get { return this.name; }
        private set { this.name = value; }
    }

    public int MinDamage
    {
        get { return this.minDamage; }
        protected set { this.minDamage = value; }
    }

    public int MaxDamage
    {
        get { return this.maxDamage; }
        protected set { this.maxDamage = value; }
    }

    public int Sockets
    {
        get { return this.sockets; }
        protected set { this.sockets = value; }
    }

    public RarityLevel RarityLevel
    {
        get { return this.rarityLevel; }
        private set { this.rarityLevel = value; }
    }

    public IGem[] Gems
    {
        get { return this.gems; }
        protected set { this.gems = value; }
    }

    public int GetStrength()
    {
        return this.Gems.Where(gem => gem != null).Sum(gem => gem.Strength);
    }

    public int GetAgility()
    {
        return this.Gems.Where(gem => gem != null).Sum(gem => gem.Agility);
    }

    public int GetVitality()
    {
        return this.Gems.Where(gem => gem != null).Sum(gem => gem.Vitality);
    }

    public int GetMinDamage()
    {
        return this.minDamage + (this.GetStrength() * Constants.MinDamageIncreasingModifierByStrength) + this.GetAgility();
    }

    public int GetMaxDamage()
    {
        return this.maxDamage + (this.GetStrength() * Constants.MaxDamageIncreasingModifierByStrength) + (this.GetAgility() * Constants.MaxDamageIncreasingModifierByAgility);
    }

    public virtual void ModifyStats()
    {
        switch (this.RarityLevel)
        {
            case RarityLevel.Common:
                this.MinDamage *= (int)RarityLevel.Common;
                this.MaxDamage *= (int)RarityLevel.Common;
                break;

            case RarityLevel.Uncommon:
                this.MinDamage *= (int)RarityLevel.Uncommon;
                this.MaxDamage *= (int)RarityLevel.Uncommon;
                break;

            case RarityLevel.Rare:
                this.MinDamage *= (int)RarityLevel.Rare;
                this.MaxDamage *= (int)RarityLevel.Rare;
                break;

            case RarityLevel.Epic:
                this.MinDamage *= (int)RarityLevel.Epic;
                this.MaxDamage *= (int)RarityLevel.Epic;
                break;
        }
    }

    public override string ToString()
    {
        return $"{this.Name}: {this.GetMinDamage()}-{this.GetMaxDamage()} Damage, +{this.GetStrength()} Strength, +{this.GetAgility()} Agility, +{this.GetVitality()} Vitality";
    }
}