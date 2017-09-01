using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public abstract class AbstractHero : IHero, IComparable<IHero>
{
    private long strength;
    private long agility;
    private long intelligence;
    private long hitPoints;
    private long damage;
    private IInventory inventory;

    protected AbstractHero(string name, long strength, long agility, long intelligence, long hitPoints, long damage)
    {
        this.Name = name;
        this.Strength = strength;
        this.Agility = agility;
        this.Intelligence = intelligence;
        this.HitPoints = hitPoints;
        this.Damage = damage;
        this.Inventory = new HeroInventory();
    }

    public string Name { get; }

    public long Strength
    {
        get { return this.strength + this.inventory.TotalStrengthBonus; }
        private set { this.strength = value; }
    }

    public long Agility
    {
        get { return this.agility + this.inventory.TotalAgilityBonus; }
        private set { this.agility = value; }
    }

    public long Intelligence
    {
        get { return this.intelligence + this.inventory.TotalIntelligenceBonus; }
        private set { this.intelligence = value; }
    }

    public long HitPoints
    {
        get { return this.hitPoints + this.inventory.TotalHitPointsBonus; }
        private set { this.hitPoints = value; }
    }

    public long Damage
    {
        get { return this.damage + this.inventory.TotalDamageBonus; }
        private set { this.damage = value; }
    }

    public long PrimaryStats
    {
        get { return this.Strength + this.Agility + this.Intelligence; }
    }

    public long SecondaryStats
    {
        get { return this.HitPoints + this.Damage; }
    }

    public IInventory Inventory
    {
        get { return this.inventory; }
        private set { this.inventory = value; }
    }

    public ICollection<IItem> Items
    {
        get
        {
            return ((IDictionary<string, IItem>)typeof(HeroInventory)
                     .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                     .FirstOrDefault(f => f.IsDefined(typeof(ItemAttribute)))
                     .GetValue(this.inventory))
                     .Values;
        }
    }

    public int CompareTo(IHero other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }

        if (ReferenceEquals(null, other))
        {
            return 1;
        }

        int primary = this.PrimaryStats.CompareTo(other.PrimaryStats);

        if (primary != 0)
        {
            return primary;
        }

        return this.SecondaryStats.CompareTo(other.SecondaryStats);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Hero: {this.Name}, Class: {this.GetType()}");
        sb.AppendLine($"HitPoints: {this.HitPoints}, Damage: {this.Damage}");
        sb.AppendLine($"Strength: {this.Strength}");
        sb.AppendLine($"Agility: {this.Agility}");
        sb.AppendLine($"Intelligence: {this.Intelligence}");
        sb.Append($"Items:");
        sb.AppendLine(this.Items.Count == 0 ? " None" : $"{Environment.NewLine}{string.Join(Environment.NewLine, this.Items)}");

        return sb.ToString().Trim();
    }
}