using System.Collections.Generic;
using System.Linq;

public class WeaponRepository
{
    private IList<Weapon> weapons;

    public WeaponRepository()
    {
        this.weapons = new List<Weapon>();
    }

    public void AddWeapon(Weapon weapon)
    {
        this.weapons.Add(weapon);
    }

    public void AddGem(string weaponName, int socketIndex, Gem gem)
    {
        Weapon weapon = this.FindWeaponByName(weaponName);

        if (socketIndex < weapon.Gems.Length)
        {
            weapon.Gems[socketIndex] = gem;
        }
    }

    public void RemoveGem(string weaponName, int socketIndex)
    {
        Weapon weapon = this.FindWeaponByName(weaponName);

        if (socketIndex < weapon.Gems.Length)
        {
            weapon.Gems[socketIndex] = null;
        }
    }

    public Weapon FindWeaponByName(string weaponName)
    {
        return this.weapons.FirstOrDefault(weapon => weapon.Name == weaponName);
    }
}