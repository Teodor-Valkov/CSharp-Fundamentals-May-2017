namespace Emergency.IO.Commands
{
    using Contracts.Core;
    using System.Collections.Generic;

    public class ProcessEmergenciesCommand : Command
    {
        public ProcessEmergenciesCommand(IManagementSystem managementSystem, IList<string> parameters)
            : base(managementSystem, parameters)
        {
        }

        public override string Execute()
        {
            string emergencyType = this.Parameters[0];
            return this.ManagementSystem.ProcessEmergencies(emergencyType);
        }
    }
}