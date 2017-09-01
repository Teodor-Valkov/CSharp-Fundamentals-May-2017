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

    public string Name { get; private set; }

    public long Strength
    {
        get { return this.strength + this.Inventory.TotalStrengthBonus; }
        private set { this.strength = value; }
    }

    public long Agility
    {
        get { return this.agility + this.Inventory.TotalAgilityBonus; }
        private set { this.agility = value; }
    }

    public long Intelligence
    {
        get { return this.intelligence + this.Inventory.TotalIntelligenceBonus; }
        private set { this.intelligence = value; }
    }

    public long HitPoints
    {
        get { return this.hitPoints + this.Inventory.TotalHitPointsBonus; }
        private set { this.hitPoints = value; }
    }

    public long Damage
    {
        get { return this.damage + this.Inventory.TotalDamageBonus; }
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

    public ICollection<IItem> Items
    {
        get
        {
            FieldInfo commonItemsField = typeof(HeroInventory)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.GetCustomAttribute(typeof(ItemAttribute)) != null);

            IDictionary<string, IItem> commonItems = (IDictionary<string, IItem>)commonItemsField.GetValue(this.Inventory);

            return commonItems.Values;
        }

        //get
        //{
        //    return ((Dictionary<string, IItem>)typeof(HeroInventory)
        //                 .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
        //                 .FirstOrDefault(f => f.GetCustomAttributes(typeof(ItemAttribute)) != null)
        //                 .GetValue(this.inventory)).Values;
        //}

        //get
        //{
        //    FieldInfo[] inventoryFields = typeof(HeroInventory)
        //        .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

        //    foreach (FieldInfo field in inventoryFields)
        //    {
        //        ItemAttribute itemAttribute = (ItemAttribute)field.GetCustomAttributes(typeof(ItemAttribute) != null).FirstOrDefault();

        //        if (itemAttribute != null)
        //        {
        //            IDictionary<string, IItem> commonItems = (IDictionary<string, IItem>)field.GetValue(this.Inventory);

        //            return commonItems.Values;
        //        }
        //    }

        //    throw new InvalidOperationException("Exception in Reflection of AbstractHero.cs -> Items { get; }");
        //}
    }

    public IInventory Inventory
    {
        get { return this.inventory; }
        private set { this.inventory = value; }
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