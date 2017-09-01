public class Sword : Weapon, IWeapon
{
    public Sword(string name, RarityLevel rarityLevel)
        : base(name, rarityLevel)
    {
        this.MinDamage = Constants.SwordMinDamage;
        this.MaxDamage = Constants.SwordMaxDamage;
        this.Sockets = Constants.SwordSockets;
        this.Gems = new Gem[this.Sockets];
        this.ModifyStats();
    }
}