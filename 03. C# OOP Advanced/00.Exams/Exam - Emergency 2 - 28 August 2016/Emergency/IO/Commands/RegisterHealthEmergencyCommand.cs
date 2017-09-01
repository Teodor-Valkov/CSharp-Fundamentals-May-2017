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

    public class RegisterHealthEmergencyCommand : Command
    {
        public RegisterHealthEmergencyCommand(IManagementSystem managementSystem, IList<string> parameters)
            : base(managementSystem, parameters)
        {
        }

        public override string Execute()
        {
            string description = this.Parameters[0];
            EmergencyLevel emergencyLevel = (EmergencyLevel)Enum.Parse(typeof(EmergencyLevel), this.Parameters[1]);
            IRegistrationTime registrationTime = new RegistrationTime(this.Parameters[2]);
            int casualties = int.Parse(this.Parameters[3]);

            IEmergency emergency = new HealthEmergency(description, emergencyLevel, registrationTime, casualties);

            return this.ManagementSystem.RegisterHealthEmergency(emergency);
        }
    }
}