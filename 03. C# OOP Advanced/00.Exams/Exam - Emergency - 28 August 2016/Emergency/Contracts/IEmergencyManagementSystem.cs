namespace _01.Emergency.Contracts
{
    public interface IEmergencyManagementSystem
    {
        string RegisterPropertyEmergency(IEmergency emergency);

        string RegisterHealthEmergency(IEmergency emergency);

        string RegisterOrderEmergency(IEmergency emergency);

        string RegisterFireServiceCenter(IEmergencyCenter emergencyCenter);

        string RegisterMedicalServiceCenter(IEmergencyCenter emergencyCenter);

        string RegisterPoliceServiceCenter(IEmergencyCenter emergencyCenter);

        string ProcessEmergencies(string type);

        string EmergencyReport();
    }
}