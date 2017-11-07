namespace FourFlagsRPG.Models.Models.Items.ArmorItems.FeetTypeItems
{
    using FourFlagsRPG.Models.Enums;

    public class Vambraces : ArmorItem
    {
        private const int DefenceBonusPoints = 11;
        private const string FeetArmorName = "Vambraces";

        public Vambraces(int id)
            : base(id, FeetArmorName, DefenceBonusPoints, ArmorType.Feet)
        {
        }
    }
}