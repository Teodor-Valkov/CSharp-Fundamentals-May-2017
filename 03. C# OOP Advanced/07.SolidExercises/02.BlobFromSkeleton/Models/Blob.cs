namespace _02.BlobFromSkeleton.Models
{
    using Contracts;
    using System;

    public class Blob
    {
        private int health;
        private int initialHealth;
        private bool behaviourTriggeredInThisTurn;
        private IAttack attack;
        private IBehaviour behaviour;

        public Blob(string name, int health, int damage, IBehaviour behaviour, IAttack attack)
        {
            this.Name = name;
            this.Health = health;
            this.initialHealth = health;
            this.Damage = damage;
            this.behaviour = behaviour;
            this.attack = attack;
        }

        public string Name { get; private set; }

        public int Health
        {
            get { return this.health; }
            set
            {
                this.health = value;

                if (this.health < 0)
                {
                    this.health = 0;
                }

                this.CheckForBehaviourTrigger();
            }
        }

        public int Damage { get; set; }

        private void CheckForBehaviourTrigger()
        {
            if (this.Health <= this.initialHealth / 2 && !this.behaviour.IsTriggered)
            {
                this.TriggerBehaviour();
            }
        }

        private void TriggerBehaviour()
        {
            if (this.behaviour.IsTriggered)
            {
                throw new ArgumentException("Behaviour was already triggered!");
            }

            this.behaviour.Trigger(this);
            this.behaviourTriggeredInThisTurn = true;
        }

        public bool IsAlive()
        {
            return this.Health > 0;
        }

        public void Attack(Blob target)
        {
            if (target.IsAlive() && this.IsAlive())
            {
                this.attack.Execute(this, target);
            }
        }

        public void MoveToNextTurn()
        {
            if (this.behaviour.IsTriggered && !this.behaviourTriggeredInThisTurn)
            {
                this.behaviour.ApplyPostTriggerEffect(this);
            }

            this.behaviourTriggeredInThisTurn = false;
        }

        public override string ToString()
        {
            if (this.Health <= 0)
            {
                return $"Blob {this.Name} KILLED";
            }

            return $"Blob {this.Name}: {this.Health} HP, {this.Damage} Damage";
        }
    }
}