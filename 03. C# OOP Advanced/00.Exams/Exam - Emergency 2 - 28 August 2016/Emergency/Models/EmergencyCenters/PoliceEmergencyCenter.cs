namespace Emergency.Models.EmergencyCenters
{
    public class PoliceEmergencyCenter : BaseEmergencyCenter
    {
        public PoliceEmergencyCenter(string name, int amountOfMaximumEmergencies)
            : base(name, amountOfMaximumEmergencies)
        {
        }
    }
}