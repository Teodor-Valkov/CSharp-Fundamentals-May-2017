using System.Collections.Generic;

public class Corporal : Soldier
{
    private const double OverallSkillMiltiplier = 2.5;
    private const int CorporalRegenerateValue = 10;

    private IReadOnlyList<string> weaponsAllowed = new List<string>
    {
       nameof(Gun),
       nameof(AutomaticMachine),
       nameof(Helmet),
       nameof(Knife),
       nameof(MachineGun)
    };

    public Corporal(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
    }

    protected override IReadOnlyList<string> WeaponsAllowed
    {
        get { return this.weaponsAllowed; }
    }

    public override double OverallSkill
    {
        get { return base.OverallSkill * OverallSkillMiltiplier; }
    }

    public override void Regenerate()
    {
        this.Endurance += this.Age + CorporalRegenerateValue;
    }
}