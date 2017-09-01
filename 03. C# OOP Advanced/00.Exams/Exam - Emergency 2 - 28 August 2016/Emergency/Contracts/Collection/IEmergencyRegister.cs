namespace Emergency.Contracts.Collection
{
    public interface IRegister<T>
    {
        int Capacity { get; }

        int Count { get; }

        void Enqueue(T emergency);

        T Dequeue();

        T Peek();

        bool IsEmpty();
    }
}