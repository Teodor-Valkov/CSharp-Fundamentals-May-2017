namespace _02.Blob.Models.Behaviours
{
    using Contracts;

    public class Inflated : IBehaviour
    {
        public void ActivateBehaviour(IBlob blob)
        {
            blob.Health += 50;
            blob.Activated = true;
        }

        public void ApplyBehaviourEachTurn(IBlob blob)
        {
            blob.Health -= 10;

            if (blob.Health < 0)
            {
                blob.Health = 0;
            }
        }
    }
}