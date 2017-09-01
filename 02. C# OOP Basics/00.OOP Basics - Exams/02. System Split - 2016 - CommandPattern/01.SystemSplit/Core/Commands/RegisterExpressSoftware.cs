namespace _01.SystemSplit.Core.Commands
{
    using Data;
    using Factories;

    public class RegisterExpressSoftware : RegisterSoftware
    {
        public RegisterExpressSoftware(string[] input, Repository repository, HardwareFactory hardwareFactory, SoftwareFactory softwareFactory)
            : base(input, repository, hardwareFactory, softwareFactory)
        {
        }

        protected override Software CreateSoftware()
        {
            return this.SoftwareFactory.CreateExpressSoftware(this.Input);
        }
    }
}