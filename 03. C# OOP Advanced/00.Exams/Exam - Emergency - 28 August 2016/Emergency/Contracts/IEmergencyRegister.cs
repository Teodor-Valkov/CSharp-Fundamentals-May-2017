namespace _01.Emergency.Contracts
{
    public interface IEmergencyRegister<T>
    {
        void EnqueueEmergency(T emergency);

        T DequeueEmergency();

        T PeekEmergency();

        int Count();

        bool IsEmpty();
    }
}