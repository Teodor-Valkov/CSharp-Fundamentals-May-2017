namespace FourFlagsRPG.Models.Models.Heroes
{
    using FourFlagsRPG.Models.Utilities;

    public class Barbarian : Hero
    {
        public Barbarian(string name)
            : base(name)
        {
            this.Health *= HeroConstants.BarbarianHealthMultiplier;
            this.Damage *= HeroConstants.BarbarianDamageMultiplier;
            this.Strength *= HeroConstants.BarbarianStrengthMultiplier;
            this.Defence *= HeroConstants.BarbarianDefenceMultiplier;
            this.Description = string.Format(HeroConstants.BarbarianDescription, this.Name);
        }
    }
}