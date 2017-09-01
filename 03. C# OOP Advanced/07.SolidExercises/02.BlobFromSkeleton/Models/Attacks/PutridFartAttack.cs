namespace _02.BlobFromSkeleton.Models.Attacks
{
    public class PutridFartAttack : Attack
    {
        public override void Execute(Blob attacker, Blob target)
        {
            target.Health -= attacker.Damage;
        }
    }
}