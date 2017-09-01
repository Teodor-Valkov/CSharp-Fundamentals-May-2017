public class Axe : Weapon, IWeapon
{
    public Axe(string name, RarityLevel rarityLevel)
        : base(name, rarityLevel)
    {
        this.MinDamage = Constants.AxeMinDamage;
        this.MaxDamage = Constants.AxeMaxDamage;
        this.Sockets = Constants.AxeSockets;
        this.Gems = new Gem[this.Sockets];
        this.ModifyStats();
    }
}