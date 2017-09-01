namespace _01.SystemSplit.Core.Commands
{
    using Data;
    using Factories;

    public abstract class Command
    {
        private string[] input;
        private Repository repository;
        private HardwareFactory hardwareFactory;
        private SoftwareFactory softwareFactory;

        protected Command(string[] input, Repository repository, HardwareFactory hardwareFactory, SoftwareFactory softwareFactory)
        {
            this.input = input;
            this.repository = repository;
            this.hardwareFactory = hardwareFactory;
            this.softwareFactory = softwareFactory;
        }

        protected string[] Input
        {
            get
            {
                return this.input;
            }
        }

        protected Repository Repository
        {
            get
            {
                return this.repository;
            }
        }

        protected HardwareFactory HardwareFactory
        {
            get
            {
                return this.hardwareFactory;
            }
        }

        protected SoftwareFactory SoftwareFactory
        {
            get
            {
                return this.softwareFactory;
            }
        }

        public abstract void Execute();
    }
}