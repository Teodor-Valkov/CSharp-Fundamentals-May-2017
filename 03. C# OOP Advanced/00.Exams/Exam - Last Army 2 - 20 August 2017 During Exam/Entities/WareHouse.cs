using System.Collections.Generic;
using System.Linq;

public class WareHouse : IWare
{
    private IDictionary<string, List<IAmmunition>> wareHouse;

    public WareHouse()
    {
        this.wareHouse = new Dictionary<string, List<IAmmunition>>();
    }

    public void AddAmmunition(IAmmunition ammunition, int amount)
    {
        if (!this.wareHouse.ContainsKey(ammunition.Name))
        {
            this.wareHouse[ammunition.Name] = new List<IAmmunition>();
        }

        List<IAmmunition> amo = new List<IAmmunition>();
        for (int i = 0; i < amount; i++)
        {
            amo.Add(ammunition);
        }

        this.wareHouse[ammunition.Name].AddRange(amo);
    }

    public void EquipArmyy(IArmy army)
    {
        IArmyy armyy = army as IArmyy;

        List<ISoldier> soldiers = armyy.Armyy.Values.SelectMany(s => s).ToList();

        foreach (ISoldier soldier in soldiers)
        {
            this.RefreshAmmunition(soldier);
        }
    }

    public void EquipArmy(IArmy army)
    {
        this.EquipArmyy(army);
    }

    public void RefreshAmmunition(ISoldier soldier)
    {
        List<string> missingWeapons = soldier.Weapons.Where(w => w.Value == null || w.Value.WearLevel <= 0).Select(w => w.Key).ToList();

        foreach (string missingWeapon in missingWeapons)
        {
            if (wareHouse.ContainsKey(missingWeapon) && wareHouse[missingWeapon].Any())
            {
                AmmunitionFactory factory = new AmmunitionFactory();
                IAmmunition ammunition = factory.CreateAmmunition(missingWeapon);

                // If we are using this syntax something strange happens with the warehouse weapons list when the wear level of that weapon falls below zero
                // Check Test 12 after the first completed mission - weapon Knife in soldier and warehouse weapon Knife List
                //
                //IAmmunition ammunition = wareHouse[missingWeapon].First();

                soldier.Weapons[ammunition.Name] = ammunition;

                if (wareHouse[missingWeapon].Count == 1)
                {
                    wareHouse.Remove(missingWeapon);
                }
                else
                {
                    wareHouse[missingWeapon].RemoveAt(0);
                }
            }
        }
    }

    public bool InitialEquip(ISoldier soldier)
    {
        for (int i = 0; i < soldier.Weapons.Count; i++)
        {
            KeyValuePair<string, IAmmunition> weapon = soldier.Weapons.ElementAt(i);

            if (this.wareHouse.ContainsKey(weapon.Key))
            {
                if (this.wareHouse.ContainsKey(weapon.Key) && this.wareHouse[weapon.Key].Any())
                {
                    AmmunitionFactory factory = new AmmunitionFactory();
                    IAmmunition ammunition = factory.CreateAmmunition(weapon.Key);

                    // If we are using this syntax something strange happens with the warehouse weapons list when the wear level of that weapon falls below zero
                    // Check Test 12 after the first completed mission - weapon Knife in soldier and warehouse weapon Knife List
                    //
                    //IAmmunition ammunition = this.wareHouse[weapon.Key].First();

                    soldier.Weapons[ammunition.Name] = ammunition;

                    if (this.wareHouse[weapon.Key].Count == 1)
                    {
                        this.wareHouse.Remove(weapon.Key);
                    }
                    else
                    {
                        this.wareHouse[weapon.Key].RemoveAt(0);
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        return true;
    }
}