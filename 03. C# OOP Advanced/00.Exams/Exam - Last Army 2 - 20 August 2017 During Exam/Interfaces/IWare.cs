public interface IWare : IWareHouse
{
    void AddAmmunition(IAmmunition ammunition, int amount);

    bool InitialEquip(ISoldier soldier);
}