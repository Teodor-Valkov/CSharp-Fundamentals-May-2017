namespace _02.BlobFromSkeleton.Models.Behaviours
{
    using Contracts;

    public abstract class Behaviour : IBehaviour
    {
        protected Behaviour()
        {
            this.IsTriggered = false;
        }

        public bool IsTriggered { get; protected set; }

        protected abstract void ApplyTriggerEffect(Blob source);

        public abstract void Trigger(Blob source);

        public abstract void ApplyPostTriggerEffect(Blob source);
    }
}