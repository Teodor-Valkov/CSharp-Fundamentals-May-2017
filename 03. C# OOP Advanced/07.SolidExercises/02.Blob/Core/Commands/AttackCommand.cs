namespace _02.Blob.Core.Commands
{
    using Attributes;
    using Contracts;

    public class AttackCommand : Command, IExecutable
    {
        [Inject]
        private IBlobRepository blobRepository;

        public AttackCommand(string[] data)
            : base(data)
        {
        }

        public override void Execute()
        {
            string attackerName = this.Data[0];
            string targetName = this.Data[1];

            this.blobRepository.Attack(attackerName, targetName);
        }
    }
}