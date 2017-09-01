using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    private const int MaxEndurance = 100;

    private double endurance;

    protected Soldier(string name, int age, double experience, double endurance)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experience;
        this.Endurance = endurance;
        this.Weapons = this.InitializeWeapons();
    }

    public string Name { get; private set; }

    public int Age { get; private set; }

    public double Experience { get; private set; }

    public double Endurance
    {
        get { return endurance; }
        protected set
        {
            this.endurance = Math.Min(value, MaxEndurance);
        }
    }

    public virtual double OverallSkill
    {
        get { return this.Experience + this.Age; }
    }

    public IDictionary<string, IAmmunition> Weapons { get; private set; }

    protected abstract IReadOnlyList<string> WeaponsAllowed { get; }

    private IDictionary<string, IAmmunition> InitializeWeapons()
    {
        IDictionary<string, IAmmunition> weapons = new Dictionary<string, IAmmunition>();

        foreach (string weapon in this.WeaponsAllowed)
        {
            weapons[weapon] = null;
        }

        return weapons;
    }

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        bool hasAllEquipment = this.Weapons.Values.Count(weapon => weapon == null) == 0;

        if (!hasAllEquipment)
        {
            return false;
        }

        bool hasAllEquipmentWithPositiveWearLevel = this.Weapons.Values.Count(weapon => weapon.WearLevel <= 0) == 0;

        if (!hasAllEquipmentWithPositiveWearLevel)
        {
            return false;
        }

        return true;
    }

    public void CompleteMission(IMission mission)
    {
        this.Endurance -= mission.EnduranceRequired;
        this.Experience += mission.EnduranceRequired;

        this.AmmunitionRevision(mission.WearLevelDecrement);
    }

    private void AmmunitionRevision(double missionWearLevelDecrement)
    {
        IEnumerable<string> weaponNames = this.Weapons.Keys.ToList();

        foreach (string weaponName in weaponNames)
        {
            this.Weapons[weaponName].DecreaseWearLevel(missionWearLevelDecrement);

            if (this.Weapons[weaponName].WearLevel <= 0)
            {
                this.Weapons[weaponName] = null;
            }
        }
    }

    public abstract void Regenerate();

    public override string ToString()
    {
        return string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);
    }
}