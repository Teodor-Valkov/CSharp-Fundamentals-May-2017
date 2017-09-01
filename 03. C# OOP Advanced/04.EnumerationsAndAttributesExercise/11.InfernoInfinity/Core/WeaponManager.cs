using System.Collections.Generic;

public class WeaponManager
{
    private WeaponRepository weaponRepository;

    public WeaponManager()
    {
        this.weaponRepository = new WeaponRepository();
    }

    public void CreateWeapon(List<string> inputArgs)
    {
        Weapon weapon = WeaponFactory.CreateWeapon(inputArgs);
        this.weaponRepository.AddWeapon(weapon);
    }

    public void AddSocket(List<string> inputArgs)
    {
        string weaponName = inputArgs[0];
        int socketIndex = int.Parse(inputArgs[1]);
        string gemArgs = inputArgs[2];

        Gem gem = GemFactory.CreateGem(gemArgs);
        this.weaponRepository.AddGem(weaponName, socketIndex, gem);
    }

    public void RemoveSocket(List<string> inputArgs)
    {
        string weaponName = inputArgs[0];
        int socketIndex = int.Parse(inputArgs[1]);

        this.weaponRepository.RemoveGem(weaponName, socketIndex);
    }

    public string GetWeaponToPrint(List<string> inputArgs)
    {
        string weaponName = inputArgs[0];
        Weapon weapon = weaponRepository.FindWeaponByName(weaponName);

        return weapon.ToString();
    }
}