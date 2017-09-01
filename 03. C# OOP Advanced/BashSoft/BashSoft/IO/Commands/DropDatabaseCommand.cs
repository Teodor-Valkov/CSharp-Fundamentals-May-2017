namespace BashSoft.IO.Commands
{
    using BashSoft.Attibutes;
    using BashSoft.Contracts;
    using Exceptions;

    [Alias("dropDb")]
    public class DropDatabaseCommand : Command, IExecutable
    {
        [Inject]
        private IDatabase studentsRepository;

        public DropDatabaseCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 1)
            {
                throw new InvalidCommandException(this.Input);
            }

            this.studentsRepository.UnloadData();
        }
    }
}