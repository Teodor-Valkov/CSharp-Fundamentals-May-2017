using System.Collections.Generic;
using System.Linq;

public class WareHouse : IWareHouse
{
    private IAmmunitionFactory ammunitionFactory;
    private IDictionary<string, int> ammunitionQuantities;

    public WareHouse()
    {
        this.ammunitionFactory = new AmmunitionFactory();
        this.ammunitionQuantities = new Dictionary<string, int>();
    }

    public void AddAmmunitions(string name, int quantity)
    {
        if (!this.ammunitionQuantities.ContainsKey(name))
        {
            this.ammunitionQuantities[name] = 0;
        }

        this.ammunitionQuantities[name] += quantity;
    }

    public void EquipArmy(IArmy army)
    {
        foreach (ISoldier soldier in army.Soldiers)
        {
            this.TryEquipSoldier(soldier);
        }
    }

    public bool TryEquipSoldier(ISoldier soldier)
    {
        bool isEquipped = true;

        List<string> missingWeapons = soldier.Weapons.Where(w => w.Value == null).Select(w => w.Key).ToList();

        foreach (string weaponName in missingWeapons)
        {
            if (this.ammunitionQuantities.ContainsKey(weaponName) && ammunitionQuantities[weaponName] > 0)
            {
                soldier.Weapons[weaponName] = this.ammunitionFactory.CreateAmmunition(weaponName);
                this.ammunitionQuantities[weaponName]--;
            }
            else
            {
                isEquipped = false;
            }
        }

        return isEquipped;
    }
}