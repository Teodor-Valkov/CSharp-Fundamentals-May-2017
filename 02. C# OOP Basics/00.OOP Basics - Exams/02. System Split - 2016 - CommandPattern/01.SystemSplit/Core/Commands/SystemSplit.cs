namespace _01.SystemSplit.Core
{
    using Commands;
    using Data;
    using Factories;

    public class SystemSplit : Command
    {
        public SystemSplit(string[] input, Repository repository, HardwareFactory hardwareFactory, SoftwareFactory softwareFactory)
            : base(input, repository, hardwareFactory, softwareFactory)
        {
        }

        public override void Execute()
        {
            this.Repository.PrintSystemSplit();
        }
    }
}