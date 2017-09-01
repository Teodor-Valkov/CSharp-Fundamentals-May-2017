namespace _02.Blob.Contracts
{
    public interface IBlob
    {
        bool Activated { get; set; }

        int ActivatedBehaviourTurns { get; set; }

        IAttack Attack { get; }

        IBehaviour Behaviour { get; }

        long Damage { get; set; }

        long Health { get; set; }

        long InitialDamage { get; set; }

        long InitialHealth { get; }

        string Name { get; }

        void ActivateBegaviourIfPossible();

        void ApplyBehaviour();

        long GetAttackDamage();
    }
}