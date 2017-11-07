namespace FourFlagsRPG.Models.Models.Heroes
{
    using Containers;
    using Contracts.Heroes;
    using Contracts.Items;
    using Events;
    using System;
    using System.Linq;
    using Utilities;

    public abstract class Hero : IHero
    {
        private string name;

        private string description;

        private int health;

        private int experience;

        private int level;

        private int damage;

        private int strength;

        private int defence;

        private int dexterity;

        private IInventory inventory;

        protected Hero(string name)
        {
            this.Name = name;
            this.Health = HeroConstants.DefaultHealth;
            this.Damage = HeroConstants.DefaultDamage;
            this.Strength = HeroConstants.DefaultStrength;
            this.Defence = HeroConstants.DefaultDefence;
            this.Dexterity = HeroConstants.DefaultDexterity;
            this.Inventory = new Inventory();
            this.Level = HeroConstants.HeroStartingLevel;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                Validator.ValidateHeroName(value);

                this.name = value;
            }
        }

        public string Description
        {
            get { return this.description; }
            protected set
            {
                this.description = value;
            }
        }

        public int Health
        {
            get { return this.health; }
            protected set
            {
                Validator.ValidateStats(value, "health", "Hero");

                this.health = value;
            }
        }

        public int Experience
        {
            get { return this.experience; }
            private set
            {
                Validator.ValidateStats(value, "experience", "Hero");

                this.experience = value;
            }
        }

        public int Level
        {
            get { return this.level; }
            private set
            {
                Validator.ValidateStats(value, "level", "Hero");

                this.level = value;
            }
        }

        public int Damage
        {
            get { return this.damage; }
            protected set
            {
                Validator.ValidateStats(value, "damage", "Hero");

                this.damage = value;
            }
        }

        public int Strength
        {
            get { return this.strength; }
            protected set
            {
                Validator.ValidateStats(value, "strength", "Hero");

                this.strength = value;
            }
        }

        public int Defence
        {
            get { return this.defence; }
            protected set
            {
                Validator.ValidateStats(value, "defence", "Hero");

                this.defence = value;
            }
        }

        public int Dexterity
        {
            get { return this.dexterity; }
            protected set
            {
                Validator.ValidateStats(value, "dexterity", "Hero");

                this.dexterity = value;
            }
        }

        public IInventory Inventory
        {
            get { return this.inventory; }
            private set
            {
                this.inventory = value;
            }
        }

        public int GetAttackDamage()
        {
            return this.Strength + this.Damage + this.Dexterity + this.Inventory.GetBonusDamage();
        }

        public string Heal()
        {
            ISlot healingItemSlot = this.inventory.BackPack.SlotList
                .FirstOrDefault(s => !s.IsEmpty && s.Item.GetType().BaseType.Name == "HealthPotion");

            if (healingItemSlot != null)
            {
                IHeal potion = healingItemSlot.Item as IHeal;
                this.health += potion.HealingPoints;
                healingItemSlot.IsEmpty = true;
                healingItemSlot.Item = null;

                return $"You have restored {potion.HealingPoints} health points!";
            }

            return $"You don't have any healing items!";
        }

        public void Collect(object sender, QuestCompletedEventArgs args)
        {
            foreach (IItem item in args.ItemRewards)
            {
                Validator.ValidateItem(item);

                this.inventory.BackPack.LootItem(item);
            }

            this.GainExperience(args.Experience);
        }

        public void TakeDamage(int damagePoints)
        {
            this.health -= damagePoints;
        }

        private void GainExperience(int experience)
        {
            Validator.ValidateStats(experience, "experience", "Hero");

            this.experience += experience;

            if (this.experience >= HeroConstants.ExperienceConstant * this.level)
            {
                this.level++;
            }
        }

        public string ShowStats()
        {
            return $"HP ==> {this.Health}{Environment.NewLine}STR ==> {this.Strength}{Environment.NewLine}DEX ==> {this.Dexterity}{Environment.NewLine}DEF ==> {this.Defence}{Environment.NewLine}EXP ==> {this.Experience}";
        }
    }
}