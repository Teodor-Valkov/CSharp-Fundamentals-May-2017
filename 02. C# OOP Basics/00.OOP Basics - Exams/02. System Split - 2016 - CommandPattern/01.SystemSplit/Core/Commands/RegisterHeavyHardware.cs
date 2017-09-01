namespace _01.SystemSplit.Core.Commands
{
    using Data;
    using Factories;

    public class RegisterHeavyHardware : RegisterHardware
    {
        public RegisterHeavyHardware(string[] input, Repository repository, HardwareFactory hardwareFactory, SoftwareFactory softwareFactory)
            : base(input, repository, hardwareFactory, softwareFactory)
        {
        }

        protected override Hardware CreateHardware()
        {
            return this.HardwareFactory.CreateHeavyHardware(this.Input);
        }
    }
}