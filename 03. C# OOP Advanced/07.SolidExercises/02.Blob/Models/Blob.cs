namespace _02.Blob.Models
{
    using Contracts;

    public class Blob : IBlob
    {
        public Blob(string name, int health, int damage, IBehaviour behaviour, IAttack attack)
        {
            this.Name = name;
            this.Health = health;
            this.InitialHealth = health;
            this.Damage = damage;
            this.InitialDamage = damage;
            this.Behaviour = behaviour;
            this.Attack = attack;
        }

        public string Name { get; private set; }

        public long Health { get; set; }

        public long InitialHealth { get; private set; }

        public long Damage { get; set; }

        public long InitialDamage { get; set; }

        public IBehaviour Behaviour { get; private set; }

        public IAttack Attack { get; private set; }

        public bool Activated { get; set; }

        public int ActivatedBehaviourTurns { get; set; }

        public void ActivateBegaviourIfPossible()
        {
            if (this.Health < 0)
            {
                this.Health = 0;
            }

            if (!this.Activated && this.InitialHealth / 2 >= this.Health)
            {
                this.Behaviour.ActivateBehaviour(this);
            }
        }

        public void ApplyBehaviour()
        {
            if (this.Activated && this.ActivatedBehaviourTurns >= 1)
            {
                this.Behaviour.ApplyBehaviourEachTurn(this);
            }
        }

        public long GetAttackDamage()
        {
            return this.Attack.GetSpecialAttackDamage(this);
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