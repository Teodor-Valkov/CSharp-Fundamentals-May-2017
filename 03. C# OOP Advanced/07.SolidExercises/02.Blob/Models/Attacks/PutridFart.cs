namespace _02.Blob.Models.Attacks
{
    using Contracts;

    public class PutridFart : IAttack
    {
        public long GetSpecialAttackDamage(IBlob blob)
        {
            return blob.Damage;
        }
    }
}