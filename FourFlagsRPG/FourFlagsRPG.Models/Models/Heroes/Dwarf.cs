namespace FourFlagsRPG.Models.Models.Heroes
{
    using Utilities;

    public class Dwarf : Hero
    {
        public Dwarf(string name)
            : base(name)
        {
            this.Health *= HeroConstants.DwarfHealthMultiplier;
            this.Dexterity *= HeroConstants.DwarfDexterityMultiplier;
            this.Damage += HeroConstants.DwarfDamageMultiplier;
            this.Defence += HeroConstants.DwarfDefenceMultiplier;
            this.Description = string.Format(HeroConstants.DwarfDescription, this.Name);
        }
    }
}