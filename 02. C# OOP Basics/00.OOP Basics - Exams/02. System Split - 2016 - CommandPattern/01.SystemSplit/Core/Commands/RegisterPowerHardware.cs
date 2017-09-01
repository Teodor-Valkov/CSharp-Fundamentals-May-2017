namespace _01.SystemSplit.Core.Commands
{
    using Data;
    using Factories;

    public class RegisterPowerHardware : RegisterHardware
    {
        public RegisterPowerHardware(string[] input, Repository repository, HardwareFactory hardwareFactory, SoftwareFactory softwareFactory)
            : base(input, repository, hardwareFactory, softwareFactory)
        {
        }

        protected override Hardware CreateHardware()
        {
            return this.HardwareFactory.CreatePowerHardware(this.Input);
        }
    }
}