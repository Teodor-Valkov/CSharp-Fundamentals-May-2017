namespace _01.Emergency.Models.Centers
{
    public class MedicalServiceCenter : EmergencyCenter
    {
        public MedicalServiceCenter(string name, int amountOfMaximumEmergencies)
            : base(name, amountOfMaximumEmergencies)
        {
        }
    }
}