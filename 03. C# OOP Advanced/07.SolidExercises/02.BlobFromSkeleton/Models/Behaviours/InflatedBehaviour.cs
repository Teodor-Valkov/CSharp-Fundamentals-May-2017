﻿namespace _02.BlobFromSkeleton.Models.Behaviours
{
    public class InflatedBehaviour : Behaviour
    {
        private const int InflatedHealthAddition = 50;
        private const int InflatedHealthDecrementer = 10;

        protected override void ApplyTriggerEffect(Blob source)
        {
            source.Health += InflatedHealthAddition;
        }

        public override void Trigger(Blob source)
        {
            this.IsTriggered = true;
            this.ApplyTriggerEffect(source);
        }

        public override void ApplyPostTriggerEffect(Blob source)
        {
            source.Health -= InflatedHealthDecrementer;
        }
    }
}