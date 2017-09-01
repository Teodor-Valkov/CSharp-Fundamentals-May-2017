namespace _01.Emergency.Core.Commands
{
    using _01.Emergency.Attrubutes;
    using _01.Emergency.Contracts;
    using _01.Emergency.Enums;
    using _01.Emergency.Models.Emergencies;
    using _01.Emergency.Utilities;
    using System;

    public class RegisterPropertyEmergencyCommand : Command
    {
        [InjectArgs]
        private string[] tokens;

        private IRegistrationTime registrationTime;
        private IEmergency emergency;

        public RegisterPropertyEmergencyCommand(IEmergencyManagementSystem managementSystem)
            : base(managementSystem)
        {
        }

        public override string Execute()
        {
            string description = this.tokens[1];
            EmergencyLevel emergencyLevel = (EmergencyLevel)Enum.Parse(typeof(EmergencyLevel), this.tokens[2]);
            this.registrationTime = this.CreateRegistrationTime(this.tokens[3]);
            int damage = int.Parse(this.tokens[4]);

            this.emergency = new PropertyEmergency(description, emergencyLevel, this.registrationTime, damage);
            return this.EmergencyManagementSystem.RegisterPropertyEmergency(this.emergency);
        }

        private IRegistrationTime CreateRegistrationTime(string registrationTimeAsString)
        {
            return new RegistrationTime(registrationTimeAsString);
        }
    }
}