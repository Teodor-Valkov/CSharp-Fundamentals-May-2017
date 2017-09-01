public interface IWeapon
{
    string Name { get; }

    int MinDamage { get; }

    int MaxDamage { get; }

    int Sockets { get; }

    RarityLevel RarityLevel { get; }

    IGem[] Gems { get; }

    void ModifyStats();

    int GetStrength();

    int GetAgility();

    int GetVitality();
}