namespace _01.SystemSplit.Core.Commands
{
    using Data;
    using Factories;

    public class Destroy : Command
    {
        public Destroy(string[] input, Repository repository, HardwareFactory hardwareFactory, SoftwareFactory softwareFactory)
            : base(input, repository, hardwareFactory, softwareFactory)
        {
        }

        public override void Execute()
        {
            string hardwareName = this.Input[1];
            this.Repository.Destroy(hardwareName);
        }
    }
}