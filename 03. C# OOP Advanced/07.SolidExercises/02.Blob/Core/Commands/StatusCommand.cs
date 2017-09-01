namespace _02.Blob.Core.Commands
{
    using Attributes;
    using Contracts;

    public class StatusCommand : Command, IExecutable
    {
        [Inject]
        private IBlobRepository blobRepository;

        public StatusCommand(string[] data)
            : base(data)
        {
        }

        public override void Execute()
        {
            this.blobRepository.GetStatus();
        }
    }
}