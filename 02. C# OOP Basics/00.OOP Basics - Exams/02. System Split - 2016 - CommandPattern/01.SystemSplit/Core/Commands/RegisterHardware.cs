namespace _01.SystemSplit.Core.Commands
{
    using Data;
    using Factories;

    public abstract class RegisterHardware : Command
    {
        protected RegisterHardware(string[] input, Repository repository, HardwareFactory hardwareFactory, SoftwareFactory softwareFactory)
            : base(input, repository, hardwareFactory, softwareFactory)
        {
        }

        private void AddHardware(Hardware hard)
        {
            this.Repository.AddHardware(hard);
        }

        public override void Execute()
        {
            Hardware hardware = this.CreateHardware();
            this.AddHardware(hardware);
        }

        protected abstract Hardware CreateHardware();
    }
}