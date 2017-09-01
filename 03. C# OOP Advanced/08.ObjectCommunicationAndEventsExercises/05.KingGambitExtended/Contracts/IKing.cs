public interface IKing
{
    void OnBeingAttacked();

    void AddUnit(ISoldier soldier);

    void AttackSoldier(string soldierName);
}