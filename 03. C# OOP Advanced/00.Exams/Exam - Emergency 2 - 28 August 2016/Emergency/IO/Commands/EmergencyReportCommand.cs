namespace Emergency.IO.Commands
{
    using Contracts.Core;
    using System.Collections.Generic;

    public class EmergencyReportCommand : Command
    {
        public EmergencyReportCommand(IManagementSystem managementSystem, IList<string> parameters)
            : base(managementSystem, parameters)
        {
        }

        public override string Execute()
        {
            return this.ManagementSystem.EmergencyReport();
        }
    }
}