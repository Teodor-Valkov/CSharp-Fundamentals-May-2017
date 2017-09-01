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

    public class RegisterPropertyEmergencyCommand : Command
    {
        public RegisterPropertyEmergencyCommand(IManagementSystem managementSystem, IList<string> parameters)
            : base(managementSystem, parameters)
        {
        }

        public override string Execute()
        {
            string description = this.Parameters[0];
            EmergencyLevel emergencyLevel = (EmergencyLevel)Enum.Parse(typeof(EmergencyLevel), this.Parameters[1]);
            IRegistrationTime registrationTime = new RegistrationTime(this.Parameters[2]);
            int propertyDamage = int.Parse(this.Parameters[3]);

            IEmergency emergency = new PropertyEmergency(description, emergencyLevel, registrationTime, propertyDamage);

            return this.ManagementSystem.RegisterPropertyEmergency(emergency);
        }
    }
}