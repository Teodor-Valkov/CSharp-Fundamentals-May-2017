namespace FourFlagsRPG.Models.Contracts.Items
{
    using FourFlagsRPG.Models.Enums;

    public interface IArmor : IItem
    {
        int DefenceBonus { get; }

        ArmorType ArmorType { get; }

        int GetAttackBonus();
    }
}