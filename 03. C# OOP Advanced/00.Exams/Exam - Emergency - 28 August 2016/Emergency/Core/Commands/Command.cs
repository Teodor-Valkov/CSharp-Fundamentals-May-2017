namespace _01.Emergency.Core.Commands
{
    using _01.Emergency.Contracts;

    public abstract class Command : IExecutable
    {
        protected Command(IEmergencyManagementSystem managementSystem)
        {
            this.EmergencyManagementSystem = managementSystem;
        }

        protected IEmergencyManagementSystem EmergencyManagementSystem { get; private set; }

        public abstract string Execute();
    }
}