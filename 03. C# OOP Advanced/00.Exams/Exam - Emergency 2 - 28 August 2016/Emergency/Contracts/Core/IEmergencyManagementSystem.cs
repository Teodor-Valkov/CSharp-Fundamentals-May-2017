namespace Emergency.Contracts.Core
{
    using Models.Emergencies;
    using Models.EmergencyCenters;

    public interface IManagementSystem
    {
        string EmergencyReport();

        string ProcessEmergencies(string type);

        string RegisterFireServiceCenter(IEmergencyCenter center);

        string RegisterHealthEmergency(IEmergency emergency);

        string RegisterMedicalServiceCenter(IEmergencyCenter center);

        string RegisterOrderEmergency(IEmergency emergency);

        string RegisterPoliceServiceCenter(IEmergencyCenter emergency);

        string RegisterPropertyEmergency(IEmergency emergency);
    }
}