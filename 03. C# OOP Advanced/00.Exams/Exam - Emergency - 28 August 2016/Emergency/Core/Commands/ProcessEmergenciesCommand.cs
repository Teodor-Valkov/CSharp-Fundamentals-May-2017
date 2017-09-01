namespace _01.Emergency.Core.Commands
{
    using _01.Emergency.Attrubutes;
    using _01.Emergency.Contracts;

    public class ProcessEmergenciesCommand : Command
    {
        [InjectType]
        private string type;

        public ProcessEmergenciesCommand(IEmergencyManagementSystem managementSystem)
            : base(managementSystem)
        {
        }

        public override string Execute()
        {
            return this.EmergencyManagementSystem.ProcessEmergencies(this.type);
        }
    }
}