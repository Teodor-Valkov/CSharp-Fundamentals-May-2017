namespace _01.SystemSplit.Core.Commands
{
    using Data;
    using Factories;

    public class DumpAnalyze : Command
    {
        public DumpAnalyze(string[] input, Repository repository, HardwareFactory hardwareFactory, SoftwareFactory softwareFactory)
            : base(input, repository, hardwareFactory, softwareFactory)
        {
        }

        public override void Execute()
        {
            this.Repository.PrintDumpAnalyze();
        }
    }
}