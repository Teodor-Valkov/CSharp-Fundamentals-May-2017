namespace _01.SystemSplit.Core.Commands
{
    using Data;
    using Factories;

    public class RegisterLightSoftware : RegisterSoftware
    {
        public RegisterLightSoftware(string[] input, Repository repository, HardwareFactory hardwareFactory, SoftwareFactory softwareFactory)
            : base(input, repository, hardwareFactory, softwareFactory)
        {
        }

        protected override Software CreateSoftware()
        {
            return this.SoftwareFactory.CreateLightSoftware(this.Input);
        }
    }
}