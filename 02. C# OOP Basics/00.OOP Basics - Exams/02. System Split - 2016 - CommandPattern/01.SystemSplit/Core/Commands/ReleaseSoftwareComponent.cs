namespace _01.SystemSplit.Core.Commands
{
    using Data;
    using Factories;
    using System.Linq;

    public class ReleaseSoftwareComponent : Command
    {
        public ReleaseSoftwareComponent(string[] input, Repository repository, HardwareFactory hardwareFactory, SoftwareFactory softwareFactory)
            : base(input, repository, hardwareFactory, softwareFactory)
        {
        }

        public override void Execute()
        {
            string hardwareName = this.Input[1];
            string softwareName = this.Input[2];

            if (this.Repository.Hardware.ContainsKey(hardwareName))
            {
                if (this.Repository.Hardware[hardwareName].Softwares.Any(software => software.Name == softwareName))
                {
                    this.Repository.Hardware[hardwareName].ReleaseSoftware(softwareName);
                    this.Repository.ReleaseSoftware(softwareName);
                }
            }
        }
    }
}