namespace _02.BlobFromSkeleton.Contracts
{
    using Models;

    public interface IBehaviour
    {
        bool IsTriggered { get; }

        void Trigger(Blob source);

        void ApplyPostTriggerEffect(Blob source);
    }
}