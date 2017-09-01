public interface IRepository
{
    string GetStatistics();

    void AddUnit(IUnit unit);

    string RemoveUnit(string unitType);
}