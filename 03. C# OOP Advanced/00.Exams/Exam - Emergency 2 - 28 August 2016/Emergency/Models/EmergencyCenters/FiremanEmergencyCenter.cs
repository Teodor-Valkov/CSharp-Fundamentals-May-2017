namespace Emergency.Models.EmergencyCenters
{
    public class FiremanEmergencyCenter : BaseEmergencyCenter
    {
        public FiremanEmergencyCenter(string name, int amountOfMaximumEmergencies)
            : base(name, amountOfMaximumEmergencies)
        {
        }
    }
}