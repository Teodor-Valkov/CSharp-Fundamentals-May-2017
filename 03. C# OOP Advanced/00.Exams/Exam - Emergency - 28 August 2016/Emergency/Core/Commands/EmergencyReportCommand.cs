namespace _01.Emergency.Core.Commands
{
    using _01.Emergency.Contracts;

    public class EmergencyReportCommand : Command
    {
        public EmergencyReportCommand(IEmergencyManagementSystem managementSystem)
            : base(managementSystem)
        {
        }

        public override string Execute()
        {
            return this.EmergencyManagementSystem.EmergencyReport();
        }
    }
}