using FourFlagsRPG.Models.Utilities;

namespace FourFlagsRPG.Models.Models.Heroes
{
    public class Paladin : Hero
    {
        public Paladin(string name)
            : base(name)
        {
            this.Health += this.Health / 2;
            this.Strength *= HeroConstants.PaladinfStrengthMultiplier;
            this.Damage += HeroConstants.PaladinDamageMultiplier;
            this.Dexterity += HeroConstants.PaladinDexterityMultiplier;
            this.Defence += HeroConstants.PaladinDefenceMultiplier;
            this.Description = string.Format(HeroConstants.PaladinDescription, this.Name);
        }
    }
}