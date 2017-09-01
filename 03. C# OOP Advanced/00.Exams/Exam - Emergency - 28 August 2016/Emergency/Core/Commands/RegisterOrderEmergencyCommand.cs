namespace _01.Emergency.Core.Commands
{
    using _01.Emergency.Attrubutes;
    using _01.Emergency.Contracts;
    using _01.Emergency.Enums;
    using _01.Emergency.Models.Emergencies;
    using _01.Emergency.Utilities;
    using System;

    public class RegisterOrderEmergencyCommand : Command
    {
        [InjectArgs]
        private string[] tokens;

        private IRegistrationTime registrationTime;
        private IEmergency emergency;

        public RegisterOrderEmergencyCommand(IEmergencyManagementSystem managementSystem)
            : base(managementSystem)
        {
        }

        public override string Execute()
        {
            string description = this.tokens[1];
            EmergencyLevel emergencyLevel = (EmergencyLevel)Enum.Parse(typeof(EmergencyLevel), this.tokens[2]);
            this.registrationTime = this.CreateRegistrationTime(this.tokens[3]);

            // Simple parsing doesn't work because you can't have 'dash' in enumeration - NonSpecial vs. Non-Special
            // Status status = (Status)Enum.Parse(typeof(Status), this.tokens[4]);

            Status status;

            switch (this.tokens[4])
            {
                case "Special":
                    status = Status.Special;
                    break;

                case "Non-Special":
                    status = Status.NonSpecial;
                    break;

                default:
                    throw new ArgumentException("Invalid status!");
            }

            this.emergency = new OrderEmergency(description, emergencyLevel, this.registrationTime, status);
            return this.EmergencyManagementSystem.RegisterOrderEmergency(this.emergency);
        }

        private IRegistrationTime CreateRegistrationTime(string registrationTimeAsString)
        {
            return new RegistrationTime(registrationTimeAsString);
        }
    }
}