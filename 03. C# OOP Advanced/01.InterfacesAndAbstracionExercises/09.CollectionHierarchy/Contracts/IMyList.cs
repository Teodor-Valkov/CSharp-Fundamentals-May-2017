namespace _09.CollectionHierarchy.Contracts
{
    public interface IMyList<T> : IAddable<T>, IRemovable<T>
    {
        int Used { get; }
    }
}