namespace _02.Blob.Models.Behaviours
{
    using Contracts;

    public class Aggressive : IBehaviour
    {
        public void ActivateBehaviour(IBlob blob)
        {
            blob.Damage *= 2;
            blob.Activated = true;
        }

        public void ApplyBehaviourEachTurn(IBlob blob)
        {
            if (blob.Damage - 5 >= blob.InitialDamage)
            {
                blob.Damage -= 5;
            }
        }
    }
}