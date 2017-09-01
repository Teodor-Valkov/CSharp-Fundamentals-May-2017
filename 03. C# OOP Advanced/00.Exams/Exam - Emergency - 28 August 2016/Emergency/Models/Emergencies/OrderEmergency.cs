namespace _01.Emergency.Models.Emergencies
{
    using _01.Emergency.Contracts;
    using _01.Emergency.Enums;
    using System;

    public class OrderEmergency : Emergency
    {
        private Status status;

        public OrderEmergency(string description, EmergencyLevel emergencyLevel, IRegistrationTime registrationTime, Status status)
            : base(description, emergencyLevel, registrationTime)
        {
            this.status = status;
        }

        public override int GetResultAfterProcessing()
        {
            switch (this.status)
            {
                case Status.Special:
                    return 1;

                case Status.NonSpecial:
                    return 0;

                default:
                    throw new ArgumentException();
            }
        }
    }
}