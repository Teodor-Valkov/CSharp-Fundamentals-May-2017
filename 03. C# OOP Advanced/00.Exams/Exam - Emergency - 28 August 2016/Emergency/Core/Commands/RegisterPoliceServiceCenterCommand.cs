﻿namespace _01.Emergency.Core.Commands
{
    using _01.Emergency.Attrubutes;
    using _01.Emergency.Contracts;
    using _01.Emergency.Models.Centers;

    public class RegisterPoliceServiceCenterCommand : Command
    {
        [InjectArgs]
        private string[] tokens;

        private IEmergencyCenter emergencyCenter;

        public RegisterPoliceServiceCenterCommand(IEmergencyManagementSystem managementSystem)
            : base(managementSystem)
        {
        }

        public override string Execute()
        {
            string emergencyCenterName = this.tokens[1];
            int amountOfEmergencies = int.Parse(tokens[2]);

            this.emergencyCenter = new PoliceServiceCenter(emergencyCenterName, amountOfEmergencies);
            return this.EmergencyManagementSystem.RegisterPoliceServiceCenter(this.emergencyCenter);
        }
    }
}