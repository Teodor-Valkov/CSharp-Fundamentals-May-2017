namespace _02.BlobFromSkeleton.Contracts
{
    using Models;

    public interface IAttack
    {
        void Execute(Blob attacker, Blob target);
    }
}