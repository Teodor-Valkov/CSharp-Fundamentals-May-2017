namespace _09.CollectionHierarchy.Contracts
{
    public interface IRemovable<T> : IAddable<T>
    {
        T Remove();
    }
}