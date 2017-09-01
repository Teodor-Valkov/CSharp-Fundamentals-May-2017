namespace Emergency.IO.Commands
{
    using Contracts.Core;
    using Contracts.Models.Emergencies;
    using Contracts.Utils;
    using Enums;
    using Models.Emergencies;
    using System;
    using System.Collections.Generic;
    using Utils;

    public class RegisterOrderEmergencyCommand : Command
    {
        public RegisterOrderEmergencyCommand(IManagementSystem managementSystem, IList<string> parameters)
            : base(managementSystem, parameters)
        {
        }

        public override string Execute()
        {
            string description = this.Parameters[0];
            EmergencyLevel emergencyLevel = (EmergencyLevel)Enum.Parse(typeof(EmergencyLevel), this.Parameters[1]);
            IRegistrationTime registrationTime = new RegistrationTime(this.Parameters[2]);
            CaseStatus caseStatus = (CaseStatus)Enum.Parse(typeof(CaseStatus), this.Parameters[3].Replace("-", ""));

            IEmergency emergency = new OrderEmergency(description, emergencyLevel, registrationTime, caseStatus);

            return this.ManagementSystem.RegisterOrderEmergency(emergency);
        }
    }
}