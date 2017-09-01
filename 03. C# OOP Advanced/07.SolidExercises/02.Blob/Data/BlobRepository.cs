namespace _02.Blob.Data
{
    using Contracts;
    using IO;
    using Models;
    using System;
    using System.Collections.Generic;

    public class BlobRepository : IBlobRepository
    {
        private IDictionary<string, Blob> blobs;
        private IWriter writer;

        public BlobRepository()
        {
            this.blobs = new Dictionary<string, Blob>();
            this.writer = new ConsoleWriter();
        }

        public void CreateBlob(string name, int health, int damage, IBehaviour behaviour, IAttack attack)
        {
            if (!blobs.ContainsKey(name))
            {
                this.blobs[name] = new Blob(name, health, damage, behaviour, attack);
            }
        }

        public void Attack(string attackerName, string targetName)
        {
            Blob attacker = this.blobs[attackerName];
            Blob target = this.blobs[targetName];

            if (attacker.Health <= 0)
            {
                throw new InvalidOperationException("Dead blobs cannot attack!");
            }

            target.Health -= attacker.GetAttackDamage();
            target.ActivateBegaviourIfPossible();

            if (attacker.Activated && attacker.ActivatedBehaviourTurns > 0)
            {
                attacker.ApplyBehaviour();
            }

            if (attacker.Activated && attacker.ActivatedBehaviourTurns == 0)
            {
                attacker.ActivatedBehaviourTurns++;
            }

            if (target.Activated && target.ActivatedBehaviourTurns > 0)
            {
                target.ApplyBehaviour();
            }

            if (target.Activated && target.ActivatedBehaviourTurns == 0)
            {
                target.ActivatedBehaviourTurns++;
            }
        }

        public void Pass()
        {
            foreach (KeyValuePair<string, Blob> blob in this.blobs)
            {
                if (blob.Value.Activated)
                {
                    blob.Value.ActivatedBehaviourTurns++;
                    blob.Value.ApplyBehaviour();
                }
            }
        }

        public void GetStatus()
        {
            foreach (KeyValuePair<string, Blob> blob in blobs)
            {
                this.writer.Writer(blob.Value.ToString());

                if (blob.Value.Activated)
                {
                    blob.Value.ActivatedBehaviourTurns++;
                    blob.Value.ApplyBehaviour();
                }
            }
        }
    }
}