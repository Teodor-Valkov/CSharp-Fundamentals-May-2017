namespace Emergency.Models.EmergencyCenters
{
    public class MedicalEmergencyCenter : BaseEmergencyCenter
    {
        public MedicalEmergencyCenter(string name, int amountOfMaximumEmergencies)
            : base(name, amountOfMaximumEmergencies)
        {
        }
    }
}