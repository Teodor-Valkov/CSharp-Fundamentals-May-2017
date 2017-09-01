namespace Emergency.IO.Commands
{
    using Attributes;
    using Contracts.Core;
    using Contracts.Factories;
    using Contracts.Models.EmergencyCenters;
    using Models.EmergencyCenters;
    using System.Collections.Generic;

    public class RegisterMedicalServiceCenterCommand : Command
    {
        [Inject]
        private IFactory factory;

        public RegisterMedicalServiceCenterCommand(IManagementSystem managementSystem, IList<string> parameters)
            : base(managementSystem, parameters)
        {
        }

        public override string Execute()
        {
            IEmergencyCenter center = this.factory.GetObject<IEmergencyCenter>(nameof(MedicalEmergencyCenter), this.Parameters);
            return this.ManagementSystem.RegisterMedicalServiceCenter(center);
        }
    }
}