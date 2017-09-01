namespace _01.SystemSplit.Core.Commands
{
    using Data;
    using Factories;

    public abstract class RegisterSoftware : Command
    {
        protected RegisterSoftware(string[] input, Repository repository, HardwareFactory hardwareFactory, SoftwareFactory softwareFactory)
            : base(input, repository, hardwareFactory, softwareFactory)
        {
        }

        public override void Execute()
        {
            string hardwareName = this.Input[1];

            if (this.Repository.Hardware.ContainsKey(hardwareName))
            {
                Software software = CreateSoftware();

                if (this.Repository.Hardware[hardwareName].CanRegisterSoftware(software))
                {
                    this.Repository.Hardware[hardwareName].RegisterSoftware(software);
                }
            }
        }

        protected abstract Software CreateSoftware();
    }
}