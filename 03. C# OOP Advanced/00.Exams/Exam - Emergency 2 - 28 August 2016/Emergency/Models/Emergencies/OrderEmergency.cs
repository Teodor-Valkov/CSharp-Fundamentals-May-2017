namespace Emergency.Models.Emergencies
{
    using Contracts.Utils;
    using Enums;

    public class OrderEmergency : BaseEmergency
    {
        public OrderEmergency(string description, EmergencyLevel emergencyLevel, IRegistrationTime registrationTime, CaseStatus caseStatus)
            : base(description, emergencyLevel, registrationTime)
        {
            this.CaseStatus = caseStatus;
        }

        public CaseStatus CaseStatus { get; }

        public override int GetProcessResult()
        {
            return (int)this.CaseStatus;
        }
    }
}