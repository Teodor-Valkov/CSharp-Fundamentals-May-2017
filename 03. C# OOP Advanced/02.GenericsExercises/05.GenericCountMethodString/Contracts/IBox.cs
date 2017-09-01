public interface IBox<T>
{
    T Data { get; }

    bool IsDataGreater(T dataToCompare);
}