namespace FourFlagsRPG.Models.Contracts.Items
{
    using FourFlagsRPG.Models.Enums;

    public interface IGameItem
    {
        ItemState ItemState { get; set; }
    }
}