namespace Emergency.IO.Commands
{
    using Attributes;
    using Contracts.Core;
    using Contracts.Factories;
    using Contracts.Models.EmergencyCenters;
    using Models.EmergencyCenters;
    using System.Collections.Generic;

    public class RegisterFireServiceCenterCommand : Command
    {
        [Inject]
        private IFactory factory;

        public RegisterFireServiceCenterCommand(IManagementSystem managementSystem, IList<string> parameters)
            : base(managementSystem, parameters)
        {
        }

        public override string Execute()
        {
            IEmergencyCenter center = this.factory.GetObject<IEmergencyCenter>(nameof(FiremanEmergencyCenter), this.Parameters);
            return this.ManagementSystem.RegisterFireServiceCenter(center);
        }
    }
}