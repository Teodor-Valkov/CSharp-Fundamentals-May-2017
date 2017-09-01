namespace _02.Blob.Contracts
{
    public interface IBehaviour
    {
        void ActivateBehaviour(IBlob blob);

        void ApplyBehaviourEachTurn(IBlob blob);
    }
}