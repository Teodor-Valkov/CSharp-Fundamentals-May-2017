namespace _02.Blob.Core.Commands
{
    using Attributes;
    using Contracts;

    public class PassCommand : Command, IExecutable
    {
        [Inject]
        private IBlobRepository blobRepository;

        public PassCommand(string[] data)
            : base(data)
        {
        }

        public override void Execute()
        {
            this.blobRepository.Pass();
        }
    }
}