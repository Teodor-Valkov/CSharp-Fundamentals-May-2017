public class Knife : Weapon, IWeapon
{
    public Knife(string name, RarityLevel rarityLevel)
        : base(name, rarityLevel)
    {
        this.MinDamage = Constants.KnifeMinDamage;
        this.MaxDamage = Constants.KnifeMaxDamage;
        this.Sockets = Constants.KnifeSockets;
        this.Gems = new Gem[this.Sockets];
        this.ModifyStats();
    }
}