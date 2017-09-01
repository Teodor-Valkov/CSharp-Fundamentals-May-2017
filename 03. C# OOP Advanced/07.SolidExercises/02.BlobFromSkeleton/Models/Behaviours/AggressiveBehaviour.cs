namespace _02.BlobFromSkeleton.Models.Behaviours
{
    public class AggressiveBehaviour : Behaviour
    {
        private const int AggressiveDamageMultiplier = 2;
        private const int AggressiveDamageDecrementer = 5;

        private int sourceInitialDamage;

        protected override void ApplyTriggerEffect(Blob source)
        {
            source.Damage *= AggressiveDamageMultiplier;
        }

        public override void Trigger(Blob source)
        {
            this.IsTriggered = true;
            this.sourceInitialDamage = source.Damage;
            this.ApplyTriggerEffect(source);
        }

        public override void ApplyPostTriggerEffect(Blob source)
        {
            source.Damage -= AggressiveDamageDecrementer;

            if (source.Damage <= this.sourceInitialDamage)
            {
                source.Damage = this.sourceInitialDamage;
            }
        }
    }
}