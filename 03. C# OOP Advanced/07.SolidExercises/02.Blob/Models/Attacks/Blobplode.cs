namespace _02.Blob.Models.Attacks
{
    using Contracts;

    public class Blobplode : IAttack
    {
        public long GetSpecialAttackDamage(IBlob blob)
        {
            blob.Health -= blob.Health / 2;

            if (blob.Health < 1)
            {
                blob.Health = 1;
            }

            blob.ActivateBegaviourIfPossible();

            return blob.Damage * 2;
        }
    }
}