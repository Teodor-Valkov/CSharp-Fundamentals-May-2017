using System.Collections.Generic;

public class Corporal : Soldier
{
    public Corporal(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
        this.GetWeapons();
    }

    public override double OverallSkill
    {
        get
        {
            return (this.Age + this.Experience) * 2.5;
        }
    }

    public override void Regenerate()
    {
        this.Endurance += this.Age + 10;

        if (this.Endurance > 100)
        {
            this.Endurance = 100;
        }
    }

    private void GetWeapons()
    {
        this.Weapons = new Dictionary<string, IAmmunition>();
        this.Weapons["Gun"] = null;
        this.Weapons["AutomaticMachine"] = null;
        this.Weapons["Helmet"] = null;
        this.Weapons["Knife"] = null;
        this.Weapons["MachineGun"] = null;
    }
}