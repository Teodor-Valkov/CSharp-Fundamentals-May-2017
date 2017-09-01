namespace _02.BlobFromSkeleton.Models.Attacks
{
    using Contracts;

    public abstract class Attack : IAttack
    {
        public abstract void Execute(Blob attacker, Blob target);
    }
}