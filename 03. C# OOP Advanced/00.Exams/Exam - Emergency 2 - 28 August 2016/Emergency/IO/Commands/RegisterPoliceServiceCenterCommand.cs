namespace Emergency.IO.Commands
{
    using Attributes;
    using Contracts.Core;
    using Contracts.Factories;
    using Contracts.Models.EmergencyCenters;
    using Models.EmergencyCenters;
    using System.Collections.Generic;

    public class RegisterPoliceServiceCenterCommand : Command
    {
        [Inject]
        private IFactory factory;

        public RegisterPoliceServiceCenterCommand(IManagementSystem managementSystem, IList<string> parameters)
            : base(managementSystem, parameters)
        {
        }

        public override string Execute()
        {
            IEmergencyCenter center = this.factory.GetObject<IEmergencyCenter>(nameof(PoliceEmergencyCenter), this.Parameters);
            return this.ManagementSystem.RegisterPoliceServiceCenter(center);
        }
    }
}