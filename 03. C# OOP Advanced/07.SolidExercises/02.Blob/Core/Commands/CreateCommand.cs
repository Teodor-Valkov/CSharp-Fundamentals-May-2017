namespace _02.Blob.Core.Commands
{
    using Attributes;
    using Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CreateCommand : Command, IExecutable
    {
        [Inject]
        private IBlobRepository blobRepository;

        public CreateCommand(string[] data)
            : base(data)
        {
        }

        public override void Execute()
        {
            string name = this.Data[0];
            int health = int.Parse(this.Data[1]);
            int damage = int.Parse(this.Data[2]);
            string behaviourAsString = this.Data[3];
            string attackAsString = this.Data[4];

            Assembly assembly = Assembly.GetExecutingAssembly();

            Type behaviourType = assembly.DefinedTypes.FirstOrDefault(t => t.Name == behaviourAsString);
            if (behaviourType == null)
            {
                throw new ArgumentException("Invalid behaviour type!");
            }
            IBehaviour behaviour = (IBehaviour)Activator.CreateInstance(behaviourType, new object[] { });

            Type attackType = assembly.DefinedTypes.FirstOrDefault(t => t.Name == attackAsString);
            if (behaviourType == null)
            {
                throw new ArgumentException("Invalid attack type!");
            }
            IAttack attack = (IAttack)Activator.CreateInstance(attackType, new object[] { });

            this.blobRepository.CreateBlob(name, health, damage, behaviour, attack);
        }
    }
}