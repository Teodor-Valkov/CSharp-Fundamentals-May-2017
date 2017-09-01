namespace BashSoft.IO.Commands
{
    using BashSoft.Attibutes;
    using BashSoft.Contracts;
    using Exceptions;

    [Alias("cdRel")]
    public class ChangeRelativePathCommand : Command, IExecutable
    {
        [Inject]
        private IDirectoryManager inputOutputManager;

        public ChangeRelativePathCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            string relativePath = this.Data[1];
            this.inputOutputManager.ChangeCurrentDirectoryRelative(relativePath);
        }
    }
}