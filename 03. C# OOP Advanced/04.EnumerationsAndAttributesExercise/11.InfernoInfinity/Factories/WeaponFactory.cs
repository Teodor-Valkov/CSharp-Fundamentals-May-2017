using System;
using System.Collections.Generic;

public class WeaponFactory
{
    public static Weapon CreateWeapon(List<string> inputArgs)
    {
        string[] weaponArgs = inputArgs[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        string weaponRarity = weaponArgs[0];
        string weaponType = weaponArgs[1];
        string weaponName = inputArgs[1];

        switch (weaponType)
        {
            case "Axe":
                return new Axe(weaponName, (RarityLevel)Enum.Parse(typeof(RarityLevel), weaponRarity));

            case "Sword":
                return new Sword(weaponName, (RarityLevel)Enum.Parse(typeof(RarityLevel), weaponRarity));

            case "Knife":
                return new Knife(weaponName, (RarityLevel)Enum.Parse(typeof(RarityLevel), weaponRarity));

            default:
                throw new Exception();
        }
    }
}